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
using System.Windows.Shapes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                
                lastChecked = value;
                // Извикване на PropertyChanged
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                
            }
        }

        public ObservableCollection<string> PersonsChecked
        { get; set; }

        public string redirectMessage
        {
            get;
            set;
        }
        public string MainCaptionText
        {
            get;
            set;
        }

        public List<Person> ExpenseDataSource
        {
            get;
            set;
        }
        public ExpenseItHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            PersonsChecked = new ObservableCollection<string>();
            redirectMessage = "View";
            MainCaptionText = "View Expense Report:";
            ExpenseDataSource = new List<Person>() {
        new Person() {
            Name = "Mike",
              Department = "Legal",
              Expenses = new List < Expense > () {
                new Expense() {
                    ExpenseType = "Lunch", ExpenseAmount = 50
                  },
                  new Expense() {
                    ExpenseType = "Transportation", ExpenseAmount = 50
                  }
              }
          },
          new Person() {
            Name = "Lisa",
              Department = "Marketing",
              Expenses = new List < Expense > () {
                new Expense() {
                    ExpenseType = "Document printing", ExpenseAmount = 50
                  },
                  new Expense() {
                    ExpenseType = "Gift", ExpenseAmount = 125
                  }
              }
          },
          new Person() {
            Name = "John",
              Department = "Engineering",
              Expenses = new List < Expense > ()

            {
              new Expense() {
                  ExpenseType = "Magazine subscription", ExpenseAmount = 50
                },
                new Expense() {
                  ExpenseType = "New machine", ExpenseAmount = 600
                },
                new Expense() {
                  ExpenseType = "Software", ExpenseAmount = 500
                }
            }
          },
          new Person() {
            Name = "Mary",
              Department = "Finance",
              Expenses = new List < Expense > () {
                new Expense() {
                  ExpenseType = "Dinner", ExpenseAmount = 100
                }
              }
          },
          new Person() {
            Name = "Theo",
              Department = "Marketing",
              Expenses = new List < Expense > () {
                new Expense() {
                  ExpenseType = "Dinner", ExpenseAmount = 100
                }
              }
          },new Person() {
            Name = "James",
              Department = "Shipping",
              Expenses = new List < Expense > () {
                new Expense() {
                  ExpenseType = "Dinner", ExpenseAmount = 200
                }
              }
          },new Person() {
            Name = "David",
              Department = "Logistics",
              Expenses = new List < Expense > () {
                new Expense() {
                  ExpenseType = "Dinner", ExpenseAmount = 100
                }
              }
          }
      };
            DataContext = this;
        }

        //public event PropertyChangedEventHandler? PropertyChanged;

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var report = new ExpenseReport(peopleListBox.SelectedItem);
            report.Width = this.Width;
            report.Height = this.Height;
            report.ShowDialog();
        }
        private void peopleListBox_SelectionChanged_1(object sender,SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;

            PersonsChecked.Add((peopleListBox.SelectedItem as Person).Name);
        }
    }
}
