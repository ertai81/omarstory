using OmarStory.Data;
using OmarStory.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
            MainViewModel mainView = DataContext as MainViewModel;
            if (mainView == null)
                return;

            Border selection = sender as Border;

            if (selection == null)
                return;

            DecisionData selectedDecision = selection.DataContext as DecisionData;

            if (selectedDecision == null)
                return;

            mainView.AnalyzeSelectedDecision(selectedDecision);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainView = DataContext as MainViewModel;
            if (mainView == null)
                return;

            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            string combinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\Data");
            saveFileDialog.InitialDirectory = System.IO.Path.GetFullPath(combinedPath);
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Guardar";
            saveFileDialog.DefaultExt = ".omarsave";
            saveFileDialog.Filter = "Omar files (*.omarsave)|*.omarsave";
            System.Windows.Forms.DialogResult result = saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != string.Empty)
                mainView.SaveData(saveFileDialog.FileName);
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainView = DataContext as MainViewModel;
            if (mainView == null)
                return;

            System.Windows.Forms.OpenFileDialog loadFileDialog = new System.Windows.Forms.OpenFileDialog();
            string combinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\Data");
            loadFileDialog.InitialDirectory = System.IO.Path.GetFullPath(combinedPath);
            loadFileDialog.RestoreDirectory = true;
            loadFileDialog.InitialDirectory = "..\\Data";
            loadFileDialog.Title = "Cargar";
            loadFileDialog.DefaultExt = ".omarsave";
            loadFileDialog.Filter = "Omar files (*.omarsave)|*.omarsave";
            System.Windows.Forms.DialogResult result = loadFileDialog.ShowDialog();

            if (loadFileDialog.FileName != string.Empty)
                mainView.LoadData(loadFileDialog.FileName);
        }
    }
}
