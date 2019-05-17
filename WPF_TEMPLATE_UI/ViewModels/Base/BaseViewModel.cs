using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEMPLATE_UI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
