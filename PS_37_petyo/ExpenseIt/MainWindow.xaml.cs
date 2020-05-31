namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ExpenseItHome homeWindow = new ExpenseItHome();
            homeWindow.Height = this.Height;
            homeWindow.Width = this.Width;
            homeWindow.Show();
            this.Close();

        }
    }
}