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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OmarStory
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            CreateMainWindowModel();
        }

        private void CreateMainWindowModel()
        {
            MainViewModel MainView = new MainViewModel();
            this.DataContext = MainView;
        }

        private void AnyKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CallNextStep();
            }
        }

        private void Window_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            MainViewModel mainView = DataContext as MainViewModel;
            if (mainView != null)
            {
                CallNextStep();
            }
        }

        private void CallNextStep()
        {
            MainViewModel mainView = DataContext as MainViewModel;
            if (mainView != null)
            {
                if (!Global.Global.IsLoadingGame)
                {
                    mainView.CallNextStep();
                }
            }
        }
    }
}
