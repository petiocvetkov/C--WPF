using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ExpenseIt.Annotations;
using ExpenseIt.Properties;

namespace ExpenseIt
{
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public string MainCaptionText { get; set; }

        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }

        public List<Person> ExpenseDataSource { get; set; }
        
        public ObservableCollection<string> PersonsChecked { get; set;}
        public ExpenseItHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
            MainCaptionText = "View Expense Report :";
            ExpenseDataSource = new List<Person>()
            {
                new Person()
                {
                    Name = "Mike",
                    Department = "Legal",
                    Expenses = new List<Expense>()
                    {
                        new Expense() {ExpenseType = "Lunch", ExpenseAmount = 50},
                        new Expense() {ExpenseType = "Transportation", ExpenseAmount = 50}
                    }
                },
                new Person()
                {
                    Name = "Lisa",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() {ExpenseType = "Document printing", ExpenseAmount = 50},
                        new Expense() {ExpenseType = "Gift", ExpenseAmount = 125}
                    }
                },
                new Person()
                {
                    Name = "John",
                    Department = "Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense() {ExpenseType = "Magazine subscription", ExpenseAmount = 50},
                        new Expense() {ExpenseType = "New machine", ExpenseAmount = 600},
                        new Expense() {ExpenseType = "Software", ExpenseAmount = 500}
                    }
                },
                new Person()
                {
                    Name = "Mary",
                    Department = "Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() {ExpenseType = "Dinner", ExpenseAmount = 100}
                    }
                },
                new Person()
                {
                    Name = "Theo",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() {ExpenseType = "Dinner", ExpenseAmount = 100}
                    }
                },
                new Person()
                {
                    Name = "James",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() {ExpenseType = "Dinner", ExpenseAmount = 20}
                    }
                },
                new Person()
                {
                    Name = "David",
                    Department = "FInance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() {ExpenseType = "Dinner", ExpenseAmount = 10}
                    }
                }
            };
        }

        private void onViewClick(object sender, RoutedEventArgs e)
        {
            ExpenseReport report = new ExpenseReport(this.peopleListBox.SelectedItem);
            report.Width = this.Width;
            report.Height = this.Height;
            report.ShowDialog();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add((peopleListBox.SelectedItem as Person).Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}