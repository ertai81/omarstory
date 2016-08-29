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

namespace OmarStory.Views
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        MainViewModel View;

        public MainView()
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
            View = DataContext as MainViewModel;
            if (View == null)
                return;

            Rectangle selectedRectangle = sender as Rectangle;

            if (selectedRectangle == null)
                return;
            int selectedOption = Converters.Support.ToInt(selectedRectangle.Name.Substring(6, 1));

            View.DecisionMade(selectedOption);
        }
    }
}
