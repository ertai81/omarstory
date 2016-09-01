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

namespace OmarStoryBuilder
{
    public partial class Dialogs : Form
    {
        Main Main;

        public int SelectedDialogId;

        private int CharacterFilter = 0;
        private string TextFilter = string.Empty;

        public Dialogs(Main main)
        {
            InitializeComponent();
            Main = main;
        }

        private void Dialogs_Load(object sender, EventArgs e)
        {
            Main.ReloadDialogs();
            GridDialogs.DataSource = Main.MainModel.AllDialogs.OrderByDescending(x => x.Id).ToList();

            //Prepare list characters
            List<string> Characters = new List<string>();
            Characters.Add("TODOS");
            Characters.AddRange(Main.MainModel.AllChars.Select(x => x.Name));
            ComboCharactersFilter.DataSource = Characters;

            foreach (DataGridViewColumn column in GridDialogs.Columns)
            {
                GridDialogs.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void GridDialogs_DoubleClick(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid == null) { return; }

            DialogData selectedDialog = grid.SelectedRows[0].DataBoundItem as DialogData;

            if (selectedDialog != null)
            {
                SelectedDialogId = selectedDialog.Id;
                this.Close();
            }
        }

        private void ComboCharactersFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CharacterFilter = ComboCharactersFilter.SelectedIndex;
            ApplyFilter();
        }

        private void TextFilterText_TextChanged(object sender, EventArgs e)
        {
            TextFilter = TextFilterText.Text;
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var filteredDialogs = Main.MainModel.AllDialogs.OrderByDescending(x => x.Id).ToList();

            //First apply the character filter
            if (CharacterFilter > 0)
            {
                filteredDialogs = filteredDialogs.Where(x => x.CharId == CharacterFilter).ToList();
            }

            //Apply the text filter
            if (TextFilter != string.Empty)
            {
                filteredDialogs = filteredDialogs.Where(x => x.Text.ToLower().Contains(TextFilter.ToLower())).ToList();
            }

            GridDialogs.DataSource = filteredDialogs;
        }

        private void ButtonResetFilter_Click(object sender, EventArgs e)
        {
            ComboCharactersFilter.SelectedIndex = 0;
            TextFilterText.Text = string.Empty;
        }
    }
}
