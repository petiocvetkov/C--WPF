using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfExample.Annotations;

namespace WpfExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand { get; set; }
        private bool canExecute = true;

        private string message = "";

        public string Message
        {
            get => message;
        }

        public string HiButtonContent
        {
            get { return "click to hi"; }
        }

        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get { return toggleExecuteCommand; }
            set { toggleExecuteCommand = value; }
        }

        public ICommand HiButtonCommand
        {
            get { return hiButtonCommand; }
            set { hiButtonCommand = value; }
        }

        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public void ShowMessage(object obj)
        {
            message = obj.ToString();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Message"));
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}