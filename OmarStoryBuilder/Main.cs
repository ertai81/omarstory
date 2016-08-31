using OmarStory.DBQueries;
using OmarStory.Global;
using OmarStory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OmarStory.Classes;
using OmarStory.Converters;

namespace OmarStoryBuilder
{
    public partial class Main : Form
    {
        public Model MainModel = new Model();

        private bool isFirstCondition
        {
            get
            {
                return TextNewConditionDialog.Text == string.Empty;
            }
        }

        private bool isFirstResult
        {
            get
            {
                return TextNewResultDialog.Text == string.Empty;
            }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ReloadItems();
            ReloadDialogs();
            ReloadDecisions();
        }

        public void ReloadDialogs()
        {
            try
            {
                using (var session = DbContext.OpenSession(MainModel.DbProvider, MainModel.CnnString))
                {
                    MainModel.AllDialogs = OmarStoryDb.SelectDialogData(session.Connection).ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ReloadDecisions()
        {
            try
            {
                using (var session = DbContext.OpenSession(MainModel.DbProvider, MainModel.CnnString))
                {
                    MainModel.AllDecisions = OmarStoryDb.SelectDecisionData(session.Connection).ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ReloadItems()
        {
            try
            {
                using (var session = DbContext.OpenSession(MainModel.DbProvider, MainModel.CnnString))
                {
                    MainModel.AllChars = OmarStoryDb.SelectCharacterData(session.Connection).ToList();
                    MainModel.AllObjects = OmarStoryDb.SelectObjectData(session.Connection).ToList();
                    MainModel.AllStatuses = OmarStoryDb.SelectStatusData(session.Connection).ToList();
                    MainModel.AllBackgrounds = OmarStoryDb.SelectBackgroundData(session.Connection).ToList();
                }

                ListObjects.DataSource = MainModel.AllObjects.Select(x => x.Name).ToList();
                ListCharacters.DataSource = MainModel.AllChars.Select(x => x.Name).ToList();
                ListStatuses.DataSource = MainModel.AllStatuses.Select(x => x.Name).ToList();
                ListBackground.DataSource = MainModel.AllBackgrounds.Select(x => x.Name).ToList();
                ComboCharacters.DataSource = MainModel.AllChars.Select(x => x.Name).ToList();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #region Buttons
        private void ButtonAddItem_Click(object sender, EventArgs e)
        {
            if (TextItemName.Text == string.Empty)
            {
                MessageBox.Show("Introduce un nombre para el item.");
            }

            //Enter in BBDD
            int result = -1;
            using (var session = DbContext.OpenSession(MainModel.DbProvider, MainModel.CnnString))
            {
                if (RadioTypeItemObject.Checked == true)
                {
                    result = OmarStoryDb.AddItemData<ObjectData>(session.Transaction, TextItemName.Text);
                }
                else if (RadioTypeItemCharacter.Checked == true)
                {
                    result = OmarStoryDb.AddItemData<CharacterData>(session.Transaction, TextItemName.Text);
                }
                else if (RadioTypeItemStatus.Checked == true)
                {
                    result = OmarStoryDb.AddItemData<StatusData>(session.Transaction, TextItemName.Text);
                }
                else if (RadioTypeItemBackground.Checked == true)
                {
                    result = OmarStoryDb.AddItemData<BackgroundData>(session.Transaction, TextItemName.Text);
                }
            }

            if (result > -1)
            {
                ReloadItems();
                TextItemName.Text = string.Empty;
            }
        }

        private void ButtonChangeBackground_Click(object sender, EventArgs e)
        {
            string selection = ListBackground.SelectedItem.ToString();
            int idNewBackground = MainModel.AllBackgrounds.Single(x => x.Name == selection).Id;
            string result = "B" + idNewBackground.ToString("0000");

            TextNewResultDialog.Text += isFirstResult ? result : "." + result;
        }

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
                id = MainModel.AllObjects.Single(x => x.Name == selection).Id;
                code = "O" + parameter;
            }
            else if (button.Name.Contains("Friend"))
            {
                if (ListCharacters.SelectedItem == null) { return; }
                string selection = ListCharacters.SelectedItem.ToString();
                id = MainModel.AllChars.Single(x => x.Name == selection).Id;
                code = "F" + parameter;
            }
            else if(button.Name.Contains("Status"))
            {
                if (ListStatuses.SelectedItem == null) { return; }
                string selection = ListStatuses.SelectedItem.ToString();
                id = MainModel.AllStatuses.Single(x => x.Name == selection).Id;
                code = "S" + parameter;
            }

            //Asks for alternate route in case it's not fulfilled
            string alternateRoute = string.Empty;
            var result = MessageBox.Show("Introducir ruta si no se cumple?", "Pregunta", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Dialogs dialogSelection = new Dialogs(this);
                dialogSelection.ShowDialog();

                if (dialogSelection.SelectedDialogId != 0)
                {
                    int selectedDialogId = dialogSelection.SelectedDialogId;
                    alternateRoute = "D" + selectedDialogId.ToString("0000");
                }
            }

            string condition = code + id.ToString("0000") + alternateRoute;
            TextNewConditionDialog.Text += isFirstCondition ? condition : "." + condition;
        }

        private void ButtonResultItem_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            string parameter = "G";
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
                id = MainModel.AllObjects.Single(x => x.Name == selection).Id;
                code = "O" + parameter;
            }
            else if (button.Name.Contains("Friend"))
            {
                if (ListCharacters.SelectedItem == null) { return; }
                string selection = ListCharacters.SelectedItem.ToString();
                id = MainModel.AllChars.Single(x => x.Name == selection).Id;
                code = "F" + parameter;
            }
            else if (button.Name.Contains("Status"))
            {
                if (ListStatuses.SelectedItem == null) { return; }
                string selection = ListStatuses.SelectedItem.ToString();
                id = MainModel.AllStatuses.Single(x => x.Name == selection).Id;
                code = "S" + parameter;
            }

            string result = code + id.ToString("0000");
            TextNewResultDialog.Text += isFirstResult ? result : "." + result;
        }

        private void ButtonAddDialog_Click(object sender, EventArgs e)
        {
            if (TextNewTextDialog.Text == string.Empty || TextNewResultDialog.Text == string.Empty)
            {
                MessageBox.Show("Rellena todos los datos");
                return;
            }

            using (var session = DbContext.OpenSession(MainModel.DbProvider, MainModel.CnnString))
            {
                DialogData newDialog = new DialogData()
                {
                    //Order is the same as in the db but adding one
                    CharId = ComboCharacters.SelectedIndex + 1,
                    Text = TextNewTextDialog.Text,
                    Condition = TextNewConditionDialog.Text,
                    Result = TextNewResultDialog.Text
                };

                OmarStoryDb.AddDialogData(session.Transaction, newDialog);
            }

            //Updates previous Dialog or Decision if needed to
            using (var session = DbContext.OpenSession(MainModel.DbProvider, MainModel.CnnString))
            {
                
                int newDialogId = MainModel.AllDialogs.Count() + 1;

                if (MainModel.DialogToConnectTo.Id != 0)
                {
                    MainModel.DialogToConnectTo.Result = UpdateResult
                        (MainModel.DialogToConnectTo.Result, "D" + newDialogId.ToString("0000"));
                    OmarStoryDb.UpdateDialogData(session.Transaction, MainModel.DialogToConnectTo);

                }
                else if (MainModel.DecisionToConnectTo.Id != 0)
                {
                    MainModel.DecisionToConnectTo.Result = UpdateResult(
                        MainModel.DecisionToConnectTo.Result, "D" + newDialogId.ToString("0000"));
                    OmarStoryDb.UpdateDecisionData(session.Transaction, MainModel.DecisionToConnectTo);
                }
            }

            Reset();
        }

        public string UpdateResult(string resultOriginal, string newNextStep)
        {
            List<Result> results = Deserialize.ToListResults(resultOriginal).ToList();
            
            foreach(var result in results)
            {
                if (result.Code == "D" || result.Code == "Q")
                {
                    result.Raw = newNextStep;
                }
            }

            return Deserialize.FromListResults(results);
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            ComboCharacters.SelectedIndex = 0;
            TextNewTextDialog.Text = TextNewResultDialog.Text = TextNewConditionDialog.Text = String.Empty;

            MainModel.DialogToConnectTo = new DialogData();
            MainModel.DecisionToConnectTo = new DecisionData();
            TextConnectToStepText.Text = string.Empty;

            ReloadItems();
        }

        private void ButtonNextDialog_Click(object sender, EventArgs e)
        {
            string nextDialog = string.Empty;
            Dialogs dialogSelection = new Dialogs(this);
            dialogSelection.ShowDialog();

            if (dialogSelection.SelectedDialogId != 0)
            {
                int selectedDialogId = dialogSelection.SelectedDialogId;
                nextDialog = "D" + selectedDialogId.ToString("0000");
            }
            TextNewResultDialog.Text += isFirstResult ? nextDialog : "." + nextDialog;
        }

        private void ButtonNextDecision_Click(object sender, EventArgs e)
        {
            string nextDecision = string.Empty;
            Decisions decisionSelection = new Decisions(this);
            decisionSelection.ShowDialog();

            if (decisionSelection.SelectedDecisionId != 0)
            {
                int selectedDialogId = decisionSelection.SelectedDecisionId;
                nextDecision = "Q" + selectedDialogId.ToString("0000");
            }
            TextNewResultDialog.Text += isFirstResult ? nextDecision : "." + nextDecision;
        }

        private void ButtonAddDecision_Click(object sender, EventArgs e)
        {
            MainDecision newDecision = new MainDecision(this);
            newDecision.Show();
        }

        private void ButtonConnectToDialog_Click(object sender, EventArgs e)
        {
            Dialogs dialogSelection = new Dialogs(this);
            dialogSelection.ShowDialog();

            if (dialogSelection.SelectedDialogId != 0)
            {
                int selectedDialogId = dialogSelection.SelectedDialogId;

                MainModel.DecisionToConnectTo = new DecisionData();
                MainModel.DialogToConnectTo = MainModel.AllDialogs.Single(x => x.Id == selectedDialogId);
                
                TextConnectToStepText.Text = MainModel.DialogToConnectTo.Text;
            }
        }

        private void ButtonConnectToDecision_Click(object sender, EventArgs e)
        {
            Decisions decisionSelection = new Decisions(this);
            decisionSelection.ShowDialog();

            if (decisionSelection.SelectedDecisionId != 0)
            {
                int selectedDecisionId = decisionSelection.SelectedDecisionId;
                int selectedDecisionOption = decisionSelection.SelectedDecisionOption;

                MainModel.DialogToConnectTo = new DialogData();
                MainModel.DecisionToConnectTo = MainModel.AllDecisions.Single(x =>
                    x.Id == selectedDecisionId && x.Option == selectedDecisionOption);
                
                TextConnectToStepText.Text = MainModel.DecisionToConnectTo.Text;
            }
        }
        #endregion

        private void TextNewTextDialog_TextChanged(object sender, EventArgs e)
        {
            if (TextNewTextDialog.Text.Length > 190)
            {
                MessageBox.Show("Límite de caracteres alcanzado");
                TextNewTextDialog.Text = TextNewTextDialog.Text.Substring(0, 190);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void TextConnectToStepText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
