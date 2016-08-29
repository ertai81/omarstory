using OmarStory.Actions;
using OmarStory.Classes;
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
            Inventory CurrentInventory = new Inventory();
            ChangeCharacter("Omar");

            ShowDialog(1);
            //ShowDecision(1);
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
            Global.AllItemsDB.AllChars = new List<Char>();
            AllItemsDB.AllChars.Add(new Char { Id = 1, Name = "Omar" });

            //
            //using (var db = new OmarStoryEntities())
            //{
            //    Global.AllItemsDB.AllChars = db.Chars.ToList();
            //    Global.AllItemsDB.AllObjects = db.Objects.ToList();
            //    Global.AllItemsDB.AllStatuses = db.Statuses.ToList();
            //    Global.AllItemsDB.AllBackgrounds = db.Backgrounds.ToList();
            //}
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
            using (var db = new OmarStoryEntities())
            {
                try
                {
                    Model.CurrentChar = db.Chars.Single(x => x.Id == id);
                    UpdateCurrentCharImage(Model.CurrentChar.Name);
                }
                catch
                {
                    ShowError("Personaje no encontrado");
                }
            }
        }
        #endregion

        #region Dialogs
        public void ShowDialog(int id)
        {
            CharDialog dialog;
            try
            {
                //Gets dialog
                dialog = new CharDialog();
                dialog.Id = 1;
                dialog.CharId = 1;
                dialog.Condition = "";
                dialog.Text = "TEST";
                dialog.Result = "Q0001";

                //using (var db = new OmarStoryEntities())
                //{
                //    dialog = db.CharDialogs.Single(x => x.Id == id);
                //}

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
                actions.AnalizeResult();
            }
            catch
            {
                ShowError("Dialog not found");
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
            //Prepares variables
            IsWaitingForDecision = true;

            //Clear previous options
            Model.Decisions = new ObservableCollection<Decision>();

            //Show options
            Model.DecisionsVisibility = System.Windows.Visibility.Visible;

            List<Decision> decisions = new List<Decision>();

            ////////////
            //using (var db = new OmarStoryEntities())
            //{
            //    decisions = db.Decisions.Where(x => x.Id == id).ToList();
            //}

            Decision dec1 = new Decision();
            dec1.Id = 1;
            dec1.Option = 0;
            dec1.Text = "Texto 1";
            dec1.Condition = "";
            dec1.Result = "D1234";

            Decision dec2 = new Decision();
            dec2.Id = 1;
            dec2.Option = 1;
            dec2.Text = "Texto 2";
            dec2.Condition = "";
            dec2.Result = "D1234";

            decisions.Add(dec1);
            decisions.Add(dec2);
            ///////////

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

        public void DecisionMade(int option)
        {
            //Hide options
            Model.DecisionsVisibility = System.Windows.Visibility.Collapsed;
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
                ShowError("Imagen no encontrada");
            }
        }

        public void UpdateBackgound(int id)
        {
            try
            {
                Model.CurrentBackground = Converters.BitmapConversion.ToWpfBitmap(Resources.CharImagesList.GetBitmap[id.ToString()]);
            }
            catch
            {
                ShowError("Fondo no encontrado");
            }
        }
        #endregion
    }
}
