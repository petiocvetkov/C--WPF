using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using EasyMVVM.Annotations;

namespace EasyMVVM
{
    public class MainWindowVM_ : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM_()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

        private ObservableCollection<string> _BackingProperty;

        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set
            {
                _BackingProperty = value;
                PropChanged("BoundProperty");
            }
        }
        
        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}