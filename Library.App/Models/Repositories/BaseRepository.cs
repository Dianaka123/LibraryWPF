using System.Collections.ObjectModel;

namespace Library.App.Models.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected ObservableCollection<T> _records = new ObservableCollection<T>();

        public ReadOnlyObservableCollection<T> Records;

        public BaseRepository()
        {
            Records = new ReadOnlyObservableCollection<T>(_records);
        }

        public virtual bool Add(T entity)
        {
            if (_records.Contains(entity) || entity == null) return false;

            _records.Add(entity);
            return true;
        }

        public virtual void Remove(T entity)
        {
            if (!_records.Contains(entity)) return;

            _records.Remove(entity);
        }

        protected virtual IEnumerable<T> FindInRecords(Func<T, string> selectStringField, string search)
        {
            if (string.IsNullOrEmpty(search)) return _records;

            return _records.Where(r => selectStringField(r).Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        protected virtual bool ContainRecord(Func<T, string> selectStringField, string search)
        {
            if (string.IsNullOrEmpty(search)) return true;

            return _records.Any(r => selectStringField(r).Contains(search, StringComparison.OrdinalIgnoreCase));
        }
    }
}
