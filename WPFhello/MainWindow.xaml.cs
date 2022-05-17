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
using System.ComponentModel;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    string name = ((TextBox)item).Text;
                    if (name.Length >= 2)
                    {
                        sb.Append("Здрасти ")
                            .Append(name)
                            .Append(Environment.NewLine)
                            .Append("Това е твоята първа програма на Visual Studio 2022!")
                            .Append(Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Въведеното име е много кратко!\nВъведете име с поне два символа!");
                    }
                }
            }
            MessageBox.Show(sb.ToString());
        }



        private void factorialBtn_Click(object sender, RoutedEventArgs e)
        {
            int n = Int32.Parse(txtName.Text);
            int result = 1;
            for(int i = 1; i <= n; i++)
            {
                result *= i;
            }
            MessageBox.Show(result.ToString());
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close the program?", "Exit", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Windows Presentation Foundation!");
            textBlock1.Text = DateTime.Now.ToString();
        }

        private void listBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            //MessageBox.Show("Hi " + greetingMsg); 
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }
    }
}
