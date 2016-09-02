using OmarStory.Data;
using OmarStory.DBQueries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmarStoryBuilder
{
    public partial class MainDecision : Form
    {
        Main MainView;

        List<DecisionData> Options;
        
        private int CurrentNumberOptions
        {
            get
            {
                return Options.Count();
            }
        }

        private int CurrentOption
        {
            get
            {
                return ComboOptions.SelectedIndex;
            }
        }

        private bool isFirstCondition
        {
            get
            {
                return TextNewConditionDecision.Text == string.Empty;
            }
        }

        private bool isFirstResult
        {
            get
            {
                return TextNewResultDecision.Text == string.Empty;
            }
        }

        public MainDecision(Main mainView)
        {
            InitializeComponent();

            MainView = mainView;

            Options = new List<DecisionData>();
            AddNewOption();

            ListObjects.DataSource = MainView.MainModel.AllObjects.Select(x => x.Name).ToList();
            ListCharacters.DataSource = MainView.MainModel.AllChars.Select(x => x.Name).ToList();
            ListStatuses.DataSource = MainView.MainModel.AllStatuses.Select(x => x.Name).ToList();
            ListBackground.DataSource = MainView.MainModel.AllBackgrounds.Select(x => x.Name).ToList();
        }

        #region Methods
        private void ResetFields()
        {
            TextNewTextDecision.Text = TextNewResultDecision.Text = TextNewConditionDecision.Text = String.Empty;
        }

        private void ResetAllOptions()
        {
            MainView.MainModel.DialogToConnectTo = new DialogData();
            TextConnectToStepText.Text = string.Empty;

            ComboOptions.Items.Clear();
            Options = new List<DecisionData>();
            AddNewOption();

            ResetFields();
            MainView.ReloadItems();
        }

        private void AddNewOption()
        {
            if (CurrentNumberOptions == 4)
            {
                MessageBox.Show("No puedes añadir más de 4 opciones");
            }

            //Add new option
            ComboOptions.Items.Add(CurrentNumberOptions.ToString());
            Options.Add(new DecisionData());

            ComboOptions.SelectedIndex = CurrentNumberOptions - 1;
            ResetFields();
        }
        #endregion

        #region Buttons
        private void ButtonConditionItem_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            string parameter = "Y";
            if (button.Name.Contains("Doesnt"))
            {
                parameter = "N";
            }

            string code = String.Empty;
            int id = 0;
            if (button.Name.Contains("Object"))
            {
                if (ListObjects.SelectedItem == null) { return; }
                string selection = ListObjects.SelectedItem.ToString();
                id = MainView.MainModel.AllObjects.Single(x => x.Name == selection).Id;
                code = "O" + parameter;
            }
            else if (button.Name.Contains("Friend"))
            {
                if (ListCharacters.SelectedItem == null) { return; }
                string selection = ListCharacters.SelectedItem.ToString();
                id = MainView.MainModel.AllChars.Single(x => x.Name == selection).Id;
                code = "F" + parameter;
            }
            else if (button.Name.Contains("Status"))
            {
                if (ListStatuses.SelectedItem == null) { return; }
                string selection = ListStatuses.SelectedItem.ToString();
                id = MainView.MainModel.AllStatuses.Single(x => x.Name == selection).Id;
                code = "S" + parameter;
            }

            //Asks for alternate route in case it's not fulfilled
            string alternateRoute = string.Empty;
            var result = MessageBox.Show("Introducir ruta si no se cumple?", "Pregunta", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Dialogs dialogSelection = new Dialogs(MainView);
                dialogSelection.ShowDialog();

                if (dialogSelection.SelectedDialogId != 0)
                {
                    int selectedDialogId = dialogSelection.SelectedDialogId;
                    alternateRoute = "D" + selectedDialogId.ToString("0000");
                }
            }

            string condition = code + id.ToString("0000") + alternateRoute;
            TextNewConditionDecision.Text += isFirstCondition ? condition : "." + condition;
        }

        private void ButtonResultItem_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            string parameter = "R";
            if (button.Name.Contains("Loses"))
            {
                parameter = "L";
            }

            string code = String.Empty;
            int id = 0;
            if (button.Name.Contains("Object"))
            {
                if (ListObjects.SelectedItem == null) { return; }
                string selection = ListObjects.SelectedItem.ToString();
                id = MainView.MainModel.AllObjects.Single(x => x.Name == selection).Id;
                code = "O" + parameter;
            }
            else if (button.Name.Contains("Friend"))
            {
                if (ListCharacters.SelectedItem == null) { return; }
                string selection = ListCharacters.SelectedItem.ToString();
                id = MainView.MainModel.AllChars.Single(x => x.Name == selection).Id;
                code = "F" + parameter;
            }
            else if (button.Name.Contains("Status"))
            {
                if (ListStatuses.SelectedItem == null) { return; }
                string selection = ListStatuses.SelectedItem.ToString();
                id = MainView.MainModel.AllStatuses.Single(x => x.Name == selection).Id;
                code = "S" + parameter;
            }

            string result = code + id.ToString("0000");
            TextNewResultDecision.Text += isFirstResult ? result : "." + result;
        }

        private void ButtonChangeBackground_Click(object sender, EventArgs e)
        {
            string selection = ListBackground.SelectedItem.ToString();
            int idNewBackground = MainView.MainModel.AllBackgrounds.Single(x => x.Name == selection).Id;
            string result = "B" + idNewBackground.ToString("0000");

            TextNewResultDecision.Text += isFirstResult ? result : "." + result;
        }

        private void ButtonNextDialog_Click(object sender, EventArgs e)
        {
            string nextDialog = string.Empty;
            Dialogs dialogSelection = new Dialogs(MainView);
            dialogSelection.ShowDialog();

            if (dialogSelection.SelectedDialogId != 0)
            {
                int selectedDialogId = dialogSelection.SelectedDialogId;
                nextDialog = "D" + selectedDialogId.ToString("0000");
            }
            TextNewResultDecision.Text += isFirstResult ? nextDialog : "." + nextDialog;
        }

        private void ButtonNextDecision_Click(object sender, EventArgs e)
        {
            string nextDecision = string.Empty;
            Decisions decisionSelection = new Decisions(MainView);
            decisionSelection.ShowDialog();

            if (decisionSelection.SelectedDecisionId != 0)
            {
                int selectedDialogId = decisionSelection.SelectedDecisionId;
                nextDecision = "Q" + selectedDialogId.ToString("0000");
            }
            TextNewResultDecision.Text += isFirstResult ? nextDecision : "." + nextDecision;
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ButtonAddNewOption_Click(object sender, EventArgs e)
        {
            AddNewOption();
        }

        private void ButtonAddDecisionToDB_Click(object sender, EventArgs e)
        {
            MainView.ReloadDecisions();            
            int newId = MainView.MainModel.AllDecisions.Count == 0 ? 1 :
                        MainView.MainModel.AllDecisions.Max(x => x.Id) + 1;

            using (var session = DbContext.OpenSession(MainView.MainModel.DbProvider, MainView.MainModel.CnnString))
            {
                int optionNumber = 1;

                DecisionData emptyDecision = new DecisionData();

                foreach (var option in Options)
                {
                    if (option == emptyDecision)
                    {
                        continue;
                    }

                    if (option.Text == string.Empty)
                    {
                        MessageBox.Show("Rellena todos los datos");
                        ComboOptions.SelectedIndex = Options.IndexOf(option);
                        return;
                    }
                    else
                    {
                        option.Id = newId;
                        option.Option = optionNumber;
                        optionNumber++;
                    }
                }
            }

            foreach (var option in Options)
            {
                using (var session = DbContext.OpenSession(MainView.MainModel.DbProvider, MainView.MainModel.CnnString))
                {
                    OmarStoryDb.AddDecisionData(session.Transaction, option);
                }
            }

            //Updates previous Dialog or Decision if needed to
            using (var session = DbContext.OpenSession(MainView.MainModel.DbProvider, MainView.MainModel.CnnString))
            {
                if (MainView.MainModel.DialogToConnectTo.Id != 0)
                {
                    MainView.MainModel.DialogToConnectTo.Result = MainView.UpdateResultString
                        (MainView.MainModel.DialogToConnectTo.Result, "Q" + newId.ToString("0000"));
                    OmarStoryDb.UpdateDialogData(session.Transaction, MainView.MainModel.DialogToConnectTo);
                }
            }

            ResetAllOptions();            
        }

        private void ButtonResetAll_Click(object sender, EventArgs e)
        {
            ResetAllOptions();
        }

        private void ButtonDeleteThisOption_Click(object sender, EventArgs e)
        {
            int index = CurrentOption;

            if (CurrentNumberOptions == 1)
            {
                MessageBox.Show("No puedes borrar esta opción");
                return;
            }

            Options.RemoveAt(index);
            ComboOptions.Items.RemoveAt(index);

            if (index > 0)
            {
                ComboOptions.SelectedIndex = index - 1;
            }
            else
            {
                ComboOptions.SelectedIndex = index;
            }

        }

        private void ButtonConnectToDialog_Click(object sender, EventArgs e)
        {
            Dialogs dialogSelection = new Dialogs(MainView);
            dialogSelection.ShowDialog();

            if (dialogSelection.SelectedDialogId != 0)
            {
                int selectedDialogId = dialogSelection.SelectedDialogId;

                MainView.MainModel.DecisionToConnectTo = new DecisionData();
                MainView.MainModel.DialogToConnectTo = MainView.MainModel.AllDialogs.Single(x => x.Id == selectedDialogId);

                TextConnectToStepText.Text = MainView.MainModel.DialogToConnectTo.Text;
            }
        }
        #endregion

        #region Other events
        private void ComboOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextNewTextDecision.Text = Options[CurrentOption].Text;
            TextNewConditionDecision.Text = Options[CurrentOption].Condition;
            TextNewResultDecision.Text = Options[CurrentOption].Result;
        }

        private void TextNewTextDecision_TextChanged(object sender, EventArgs e)
        {
            if (TextNewTextDecision.Text.Length > 190)
            {
                MessageBox.Show("Límite de caracteres alcanzado");
                TextNewTextDecision.Text = TextNewTextDecision.Text.Substring(0, 190);
            }

            if (Options[CurrentOption] != null)
                Options[CurrentOption].Text = TextNewTextDecision.Text;
        }

        private void TextNewConditionDecision_TextChanged(object sender, EventArgs e)
        {
            if (Options[CurrentOption] != null)
                Options[CurrentOption].Condition = TextNewConditionDecision.Text;
        }

        private void TextNewResultDecision_TextChanged(object sender, EventArgs e)
        {
            if (Options[CurrentOption] != null)
                Options[CurrentOption].Result = TextNewResultDecision.Text;
        }
        #endregion
    }
}
