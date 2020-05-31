using System.Windows;
using System.Windows.Controls;

namespace ExpenseIt
{
    public partial class ExpenseReport : Window
    {
        
        public ExpenseReport(object data)
            : this()
        {
            this.DataContext = data;
        }
        public ExpenseReport()    
        {
            InitializeComponent();
        }
    }
}