using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace LibraryApp.Models
{
    public class MathFuncBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ObservableCollection<int> _myValues = new ObservableCollection<int>();
        public readonly ReadOnlyObservableCollection<int> MyValues;
        
        public int Sum => _myValues.Sum();

        public MathFuncBase()
        {
            MyValues = new ReadOnlyObservableCollection<int>(_myValues);
        }

        public void AddValue(int value)
        {
            _myValues.Add(value);
            OnPropertyChanged("Sum");
        }

        public void RemoveValue(int index)
        {
            if (index >= 0 && index < _myValues.Count)
            {
                _myValues.RemoveAt(index);
            }
            OnPropertyChanged("Sum");
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
