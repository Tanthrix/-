using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_7.VewModel.Helpers
{
    internal class BindingHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected void Set<T>(ref T field, T value, [CallerMemberName] string propName = "")
        {
            if (field != null)
            {
                if (!field.Equals(value))
                {
                    field = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        }
    }
}
