using LibraryApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class SumVM : BindableBase
    {
        readonly MathFunc _model = new MathFunc();

        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }
        public int Sum => _model.Sum;
        public ReadOnlyObservableCollection<int> MyValues => _model.MyValues;

        public SumVM()
        {
            _model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            AddCommand = new DelegateCommand<string>(str =>
            {
                if(int.TryParse(str, out int num)) _model.AddValue(num);
            });

            RemoveCommand = new DelegateCommand<int?>(index => {
                if (index.HasValue)
                {
                    _model.RemoveValue(index.Value);
                }
            });
        }
    }
}
