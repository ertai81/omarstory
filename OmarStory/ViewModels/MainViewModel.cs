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

            //Triggers
        }

        public void NewGame()
        {
            Model.CurrentInventory = new Inventory();
            ChangeCharacter("Omar");
            UpdateBackgound("Aeropuerto");

            ShowDialog(1);
        }

        #region Next step
        public Step NextStep
        {
            get
            {
                return Model.NextStep;
            }
            set
            {
                Model.NextStep = value;
                NotifyPropertyChanged();
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
            try
            {
                Model.CurrentChar = Global.AllItemsDB.AllChars.Single(x => x.Name == name);
                UpdateCurrentCharImage(Model.CurrentChar.Name);
            }
            catch
            {
                ShowError("Personaje no encontrado");
            }
        }

        public void ChangeCharacter(int id)
        {
            try
            {
                Model.CurrentChar = Global.AllItemsDB.AllChars.Single(x => x.Id == id);
                UpdateCurrentCharImage(Model.CurrentChar.Name);
            }
            catch
            {
                ShowError("Personaje no encontrado");
            }
        }
        #endregion

        #region Dialogs
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

                //Analizes Result
                actions.AnalizeResults();
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

        #region Images
        private void UpdateCurrentCharImage(string name)
        {
            try
            {
                Model.CurrentCharImage = Converters.BitmapConversion.ToWpfBitmap(Resources.CharImagesList.GetBitmap[name]);
            }
            catch
            {
                ShowError(String.Format("Imagen no encontrada: {0}", name));
            }
        }

        public void UpdateBackgound(string name)
        {
            try
            {
                Model.CurrentBackground = Converters.BitmapConversion.ToWpfBitmap(Resources.BackgroundImagesList.GetBitmap[name]);
            }
            catch
            {
                ShowError(String.Format("Fondo no encontrado: {0}", name));
            }
        }
        #endregion

        #region Save data
        public void SaveData()
        {
            string stringSave = string.Empty;

            //Save current dialog/decision
            stringSave = 

            //Save background

            //Save items
        }
        #endregion
    }
}
