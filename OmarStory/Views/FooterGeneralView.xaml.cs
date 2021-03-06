﻿using OmarStory.ViewModels;
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
    /// Lógica de interacción para FooterGeneralView.xaml
    /// </summary>
    public partial class FooterGeneralView : UserControl
    {
        MainViewModel MainView;

        public FooterGeneralView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            MainView = DataContext as MainViewModel;
            if (MainView == null)
                return;
        }
    }
}
