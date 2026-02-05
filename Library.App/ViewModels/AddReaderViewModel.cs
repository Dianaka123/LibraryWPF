using Library.App.Models.Commands;
using Library.App.Models.Entities;
using Library.App.Models.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Library.App.ViewModels
{
    public class AddReaderViewModel : INotifyPropertyChanged
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

        public ICommand CreateReaderCommand;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event Action? RequestClose;

        public AddReaderViewModel(ReaderRepository repository)
        {
            CreateReaderCommand = new RelayCommand((o) => CreateReader());
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
