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
        
        public Dialogs(Main main)
        {
            InitializeComponent();
            Main = main;
        }

        private void Dialogs_Load(object sender, EventArgs e)
        {
            Main.ReloadDialogs();
            GridDialogs.DataSource = Main.MainModel.AllDialogs.OrderByDescending(x => x.Id).ToList();

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
    }
}
