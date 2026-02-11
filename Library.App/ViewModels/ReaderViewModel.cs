using Library.App.DI;
using Library.App.Models.Commands;
using Library.App.Models.Entities;
using Library.App.Models.Repositories;
using Library.App.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;

namespace Library.App.ViewModels
{
    public class ReaderViewModel: INotifyPropertyChanged
    {
        private ReaderRepository _repository;
        private IFactory<AddReaderWindow> _addReaderWindowFactory;
        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                UpdateFilter();
            }
        }
        public ICollectionView Readers { get; }
        public ICommand SearchCommand { get; }
        public ICommand OpenAddReaderCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;


        public ReaderViewModel(ReaderRepository repository, IFactory<AddReaderWindow> factory)
        {
            _repository = repository;
            _addReaderWindowFactory = factory;

            Readers = CollectionViewSource.GetDefaultView(_repository.Records);
            Readers.Filter = (o) =>
                {
                    if (o is not Reader reader) return false;

                    if (string.IsNullOrEmpty(SearchText)) return true;

                    return reader.FullName.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                };

            SearchCommand = new RelayCommand((o) => Search());
            OpenAddReaderCommand = new RelayCommand((o) => OpenAddReader());
        }

        private void OpenAddReader()
        {
            var window = _addReaderWindowFactory.Create();
            window.Show();
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
