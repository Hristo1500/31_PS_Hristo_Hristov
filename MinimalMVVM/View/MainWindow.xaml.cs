using MinimalMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MinimalMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Presenter presenterUpper = new Presenter();
        private PresenterLower presenterLower = new PresenterLower();
        public MainWindow()
        {
            DataContext = presenterUpper;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LowerButton.IsChecked==true)
            {

                DataContext = this.presenterLower;
            }
            else
            {
                DataContext=this.presenterUpper;
            }
        }
    }
}
