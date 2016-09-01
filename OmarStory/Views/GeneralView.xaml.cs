using OmarStory.Data;
using OmarStory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OmarStory.Views
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class GeneralView : UserControl
    {
        MainViewModel MainView;

        public GeneralView()
        {
            InitializeComponent();
        }

        private void Options_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Options_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void Options_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainView = DataContext as MainViewModel;
            if (MainView == null)
                return;

            Border selection = sender as Border;

            if (selection == null)
                return;

            DecisionData selectedDecision = selection.DataContext as DecisionData;

            if (selectedDecision == null)
                return;

            MainView.AnalyzeSelectedDecision(selectedDecision);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.RestoreDirectory = true;
            saveDialog.Title = "Guardar";
            saveDialog.DefaultExt = ".omarsave";
            saveDialog.Filter = "Omar files (*.omarsave)|*.omarsave";
            DialogResult result = saveDialog.ShowDialog();

            string file = saveDialog.FileName;

            MainView.
        }
    }
}
