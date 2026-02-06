using LibraryApp.Models;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    //Without Prism
    public class SumVMBase : INotifyPropertyChanged
    {
        readonly MathFuncBase _model = new MathFuncBase();

        public event PropertyChangedEventHandler PropertyChanged;

        public ActionCommand AddCommand { get; }
        public ActionCommand RemoveCommand { get; }
        
        public int Sum => _model.Sum;
        public ReadOnlyObservableCollection<int> MyValues => _model.MyValues;

        public SumVMBase()
        {
            _model.PropertyChanged += (s, e) => { PropertyChanged?.Invoke(this, e); };
            AddCommand = new ActionCommand(str =>
            {
                if(int.TryParse((string)str, out int num)) _model.AddValue(num);
            });
            RemoveCommand = new ActionCommand(index =>
            {
                if (index != null) _model.RemoveValue((int)index);
            });
        }

    }
}
