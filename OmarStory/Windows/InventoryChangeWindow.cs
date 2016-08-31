using OmarStory.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmarStory.Windows
{
    public partial class InventoryChangeWindow : Form
    {
        public InventoryChangeWindow(Result result)
        {
            InitializeComponent();

            this.Text = String.Format("{0} {1}", 
                Resources.Strings.Action[result.Action], 
                Resources.Strings.Codes[result.Code]);

            TextInventoryChange.Text = String.Format("{0} un {1}: {2}",
                Resources.Strings.Action[result.Action], 
                Resources.Strings.Codes[result.Code],
                Converters.Support.GetNameItem(result));
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
