using Library.App.Models.Commands;
using Library.App.Models.Entities;
using Library.App.Models.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Library.App.ViewModels
{
    public class AddReaderViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly ReaderRepository _repository;

        private string _name;
        private string _lastName;
        private string _patronymic;
        private DateTime _birthday;
        private string _address;

        public string Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string LastName {
            get => _lastName;
            set {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Patronymic { get => _patronymic;
            set {
                _patronymic = value;
                OnPropertyChanged();
            }
        }
        public DateTime Birthday { get => _birthday;
            set {
                _birthday = value;
                OnPropertyChanged();
            }
        }
        public string Address { get => _address;
            set {
                _address = value;
                OnPropertyChanged();
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get 
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name)) error = "Name is required";
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName)) error = "Last name is required";
                        break;
                    case nameof(Address):
                        if (string.IsNullOrWhiteSpace(Address)) error = "Address is required";
                        else if (Address.Length < 5) error = "Address too short";
                        break;
                }
                return error;
            }
        }

        public ICommand CreateReaderCommand { get; }
        public ICommand CloseCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event Action? RequestClose;

        public AddReaderViewModel(ReaderRepository repository)
        {
            CreateReaderCommand = new RelayCommand((o) => CreateReader());
            CloseCommand = new RelayCommand((o) => RequestClose?.Invoke());
            _repository = repository;
        }

        public void CreateReader()
        {
            var reader = new Reader()
            {
                Name = Name,
                LastName = LastName,
                Patronymic = Patronymic,
                Birthday = Birthday,
                Address = Address,
            };

            if (_repository.Add(reader))
            {
                MessageBox.Show("Читатель успешно добавлен!");
                RequestClose?.Invoke();
            }
            else
            {
                MessageBox.Show("Something go wrong. Please try again");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
