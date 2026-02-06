using LibraryApp.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LibraryApp.Models.BuisnesLogic.Abstractions
{
    public class BaseRepository<T> where T : class
    {
        protected ObservableCollection<T> _records = new ObservableCollection<T>();

        public ReadOnlyObservableCollection<T> Records;

        public BaseRepository()
        {
            Records = new ReadOnlyObservableCollection<T>(_records);
        }

        public virtual void Add(T entity)
        {
            if (_records.Contains(entity)) return;

            _records.Add(entity);
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
    }
}
