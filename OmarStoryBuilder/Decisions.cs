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
    public partial class Decisions : Form
    {
        Main Main;

        public int SelectedDecisionId;

        public Decisions(Main main)
        {
            InitializeComponent();
            Main = main;
        }

        private void Decisions_Load(object sender, EventArgs e)
        {
            Main.ReloadDecisions();
            GridDecisions.DataSource = Main.MainModel.AllDecisions;
        }

        private void GridDecisions_DoubleClick(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid == null) { return; }

            DecisionData selectedDecision = grid.SelectedRows[0].DataBoundItem as DecisionData;

            if (selectedDecision != null)
            {
                SelectedDecisionId = selectedDecision.Id;
                this.Close();
            }
        }
    }
}
