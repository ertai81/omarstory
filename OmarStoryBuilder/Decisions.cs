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
        public int SelectedDecisionOption;

        string TextFilter = string.Empty;
        int DecisionNumberFilter = 0;

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
                SelectedDecisionOption = selectedDecision.Option;
                this.Close();
            }
        }

        private void TextFilterText_TextChanged(object sender, EventArgs e)
        {
            TextFilter = TextFilterText.Text;
            ApplyFilter();
        }

        private void TextDecisionNumber_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TextDecisionNumber.Text, out DecisionNumberFilter) == false)
            {
                DecisionNumberFilter = 0;
            }

            ApplyFilter();
        }

        private void ButtonResetFilter_Click(object sender, EventArgs e)
        {
            TextFilterText.Text = TextDecisionNumber.Text = string.Empty;
        }

        private void ApplyFilter()
        {
            var filteredDecisions = Main.MainModel.AllDecisions.OrderByDescending(x => x.Id).ToList();

            //First apply the character filter
            if (DecisionNumberFilter > 0)
            {
                filteredDecisions = filteredDecisions.Where(x => x.Id == DecisionNumberFilter).ToList();
            }

            //Apply the text filter
            if (TextFilter != string.Empty)
            {
                filteredDecisions = filteredDecisions.Where(x => x.Text.ToLower().Contains(TextFilter.ToLower())).ToList();
            }

            GridDecisions.DataSource = filteredDecisions;
        }
    }
}
