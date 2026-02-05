using Library.App.Models.Commands;
using Library.App.Models.Entities;
using Library.App.Models.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;

namespace Library.App.ViewModels
{
    public class ReaderViewModel: INotifyPropertyChanged
    {
        private ReaderRepository _repository;
        public ICollectionView Readers;

        private string _searchText;
        public string SearchText {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                UpdateFilter();
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand SearchCommand;
        public ICommand OpenAddReader;

        public ReaderViewModel(ReaderRepository repository)
        {
            _repository = repository;

            Readers = CollectionViewSource.GetDefaultView(_repository.Records);
            Readers.Filter = (o) =>
                {
                    if (o is not Reader reader) return false;

                    if (string.IsNullOrEmpty(SearchText)) return true;

                    return reader.FullName.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                };

            SearchCommand = new RelayCommand((o) => Search());
            //OpenAddReader = new RelayCommand((o) => OpenAddReader());
        }

        public void Search()
        {
            _repository.FindReaderByName(SearchText);
        }

        public void UpdateFilter()
        {
            Readers.Refresh();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
