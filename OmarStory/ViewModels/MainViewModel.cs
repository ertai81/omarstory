using OmarStory.Actions;
using OmarStory.Classes;
using OmarStory.Data;
using OmarStory.DBQueries;
using OmarStory.Global;
using OmarStory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OmarStory.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MainModel model;
        public MainModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Model = new MainModel();

            Initialize();
            NewGame();
        }

        public void Initialize()
        {
            //Variables
            Model.IsWaitingForDecision = false;
            Model.DecisionsVisibility = System.Windows.Visibility.Collapsed;

            GetAllItems();
        }

        public void NewGame()
        {
            Model.CurrentInventory = new Inventory();
            ChangeCharacter("Omar");
            UpdateBackgound("Aeropuerto");

            Model.CurrentStep = new Step(new Result("D0001"));
            ShowDialog(Model.CurrentStep.Id);
        }

        #region Next step
        public void CallNextStep()
        {
            //Analizes result
            if (Model.CurrentStep.IsDecision())
            {

            }
            else
            {
                DialogData currentDialog = RecoverDialog(Model.CurrentStep.Id);

                //Analizes results (gets background changes, inventory changes and next step)
                DialogActions actions = new DialogActions(this, currentDialog);
                actions.AnalizeResults();
            }

            //Current step will be replaced with the next step that it's going to load
            Model.CurrentStep = Model.NextStep;

            if (IsNextStepDecision())
            {
                ShowDecision(Model.NextStep.Id);
            }
            else
            {
                ShowDialog(Model.NextStep.Id);
            }
        }

        public void SaveNextStep(Result result)
        {
            Model.NextStep = new Step(result);
        }

        public bool IsNextStepDecision()
        {
            return Model.NextStep.IsDecision();
        }
        #endregion

        #region Characters
        private void GetAllItems()
        {
            try
            {
                using (var session = DbContext.OpenSession(Global.Global.DbProvider, Global.Global.CnnString))
                {
                    Global.AllItemsDB.AllChars = OmarStoryDb.SelectCharacterData(session.Connection).ToList();
                    Global.AllItemsDB.AllObjects = OmarStoryDb.SelectObjectData(session.Connection).ToList();
                    Global.AllItemsDB.AllStatuses = OmarStoryDb.SelectStatusData(session.Connection).ToList();
                    Global.AllItemsDB.AllBackgrounds = OmarStoryDb.SelectBackgroundData(session.Connection).ToList();
                }
            }
            catch(Exception e)
            {
                string a = e.Message;
            }
        }

        public void ChangeCharacter(string name)
        {
            ChangeCharacter(Global.AllItemsDB.AllChars.Single(x => x.Name == name).Id);
        }

        public void ChangeCharacter(int id)
        {
            try
            {
                Character newCharacter = new Character();
                newCharacter.Data = Global.AllItemsDB.AllChars.Single(x => x.Id == id);
                newCharacter.Image = Converters.BitmapConversion.ToWpfBitmap(Resources.CharImagesList.GetBitmap[newCharacter.Name]);

                Model.CurrentChar = newCharacter;
            }
            catch
            {
                ShowError("Personaje no encontrado");
            }
        }
        #endregion

        #region Dialogs
        public DialogData RecoverDialog(int id)
        {
            DialogData dialog = new DialogData();

            try
            {
                using (var session = DbContext.OpenSession(Global.Global.DbProvider, Global.Global.CnnString))
                {
                    dialog = OmarStoryDb.SelectDialogData(session.Connection, id);
                }
            }
            catch (Exception e)
            {
                ShowError(String.Format("Error buscando diálogo {0}{1}{2}", id.ToString(), Environment.NewLine, e.Message));
                return dialog;
            }

            return dialog;
        }

        public void ShowDialog(int id)
        {
            DialogData dialog;
            try
            {
                using (var session = DbContext.OpenSession(Global.Global.DbProvider, Global.Global.CnnString))
                {
                    dialog = OmarStoryDb.SelectDialogData(session.Connection, id);
                }

                DialogActions actions = new DialogActions(this, dialog);

                //Checks conditions
                if (actions.HasConditions())
                {
                    Result resultConditionsDontClear = actions.AnalizeConditions();

                    //Result is not null -> One condition didn't clear, we have to jump there
                    if (resultConditionsDontClear != null)
                    {
                        SaveNextStep(resultConditionsDontClear);
                        return;
                    }
                }

                //Changes character if necessary
                if (dialog.CharId != Model.CurrentChar.Id)
                {
                    ChangeCharacter(dialog.CharId);
                }

                //Shows dialog in the screen
                Model.CurrentText = dialog.Text;
            }
            catch(Exception e)
            {
                ShowError(String.Format("Error buscando diálogo {0}{1}{2}", id.ToString(),Environment.NewLine, e.Message));
            }
        }
        #endregion

        #region Decisions
        public bool IsWaitingForDecision
        {
            get
            {
                return Model.IsWaitingForDecision;
            }
            set
            {
                Model.IsWaitingForDecision = value;
                NotifyPropertyChanged();
            }
        }

        public void ShowDecision(int id)
        {
            try
            {
                //Prepares variables
                IsWaitingForDecision = true;

                //Clear previous options
                Model.Decisions = new ObservableCollection<DecisionData>();

                //Show options
                Model.DecisionsVisibility = System.Windows.Visibility.Visible;

                List<DecisionData> decisions = new List<DecisionData>();

                using (var session = DbContext.OpenSession(Global.Global.DbProvider, Global.Global.CnnString))
                {
                    decisions = OmarStoryDb.SelectDecisionData(session.Connection, id).ToList();
                }

                foreach (var decision in decisions)
                {
                    DecisionActions actions = new DecisionActions(this, decision);

                    //Checks conditions
                    if (actions.HasConditions())
                    {
                        Result resultConditionsDontClear = actions.AnalizeConditions();

                        //Result is not null -> One condition didn't clear, we have skip it
                        if (resultConditionsDontClear != null)
                        {
                            continue;
                        }
                    }

                    Model.Decisions.Add(decision);
                }
            }
            catch(Exception e)
            {
                ShowError(String.Format("Error buscando decisiones {0}{1}{2}", id.ToString(), Environment.NewLine, e.Message));
            }
        }

        public void AnalyzeSelectedDecision(DecisionData selectedDecision)
        {
            IsWaitingForDecision = false;

            //Hide options
            Model.DecisionsVisibility = System.Windows.Visibility.Collapsed;

            DecisionActions actions = new DecisionActions(this, selectedDecision);
            actions.AnalizeResults();
        }
        #endregion

        #region Background
        public void UpdateBackgound(string name)
        {
            try
            {
                Background newBackground = new Background();
                newBackground.Data = AllItemsDB.AllBackgrounds.Single(x => x.Name == name);
                newBackground.Image = Converters.BitmapConversion.ToWpfBitmap(Resources.BackgroundImagesList.GetBitmap[name]);
                Model.CurrentBackground = newBackground;
            }
            catch
            {
                ShowError(String.Format("Fondo no encontrado: {0}", name));
            }
        }
        #endregion

        #region Save/Load data
        public void SaveData(string file)
        {
            string stringSave = string.Empty;

            //Save current dialog/decision
            stringSave += Model.CurrentStep.Raw + ".";

            //Save background
            stringSave += "B" + Model.CurrentBackground.Id.ToString("0000") + ".";

            //Save items with "R" after the type so that the system 
            //understands that the player has to receive the item
            foreach(var obj in Global.Inventory.Objects)
            {
                stringSave += "OR" + obj.Id.ToString("0000") + ".";
            }

            foreach (var friends in Global.Inventory.Friends)
            {
                stringSave += "FR" + friends.Id.ToString("0000") + ".";
            }

            foreach (var status in Global.Inventory.Statuses)
            {
                stringSave += "SR" + status.Id.ToString("0000") + ".";
            }

            string encryptString = Crypto.EncryptStringAES(stringSave, "ogZ7aYQCv6zCky");

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            using (FileStream fs = File.Create(file))
            {
                // Add some text to file
                Byte[] saveCode = new UTF8Encoding(true).GetBytes(encryptString);
                fs.Write(saveCode, 0, saveCode.Length);
            }
        }

        public void LoadData(string file)
        {
            string encryptedString = "";
            using (StreamReader sr = File.OpenText(file))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    encryptedString += line;
                }
            }
            string loadData = Crypto.DecryptStringAES(encryptedString, "ogZ7aYQCv6zCky");

            DialogActions loadActions = new DialogActions(this, new DialogData() { Result = loadData });
            loadActions.AnalizeResults(false);
        }
        #endregion
    }
}
