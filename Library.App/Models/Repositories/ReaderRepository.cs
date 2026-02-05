using Library.App.Models.Entities;

namespace Library.App.Models.Repositories
{
    public class ReaderRepository : BaseRepository<Reader>
    {
        public IEnumerable<Reader> FindReaderByName(string name) => FindInRecords(r => r.FullName, name);

        public bool ContainsReader(string readerInfo) => ContainRecord(r => r.FullName, readerInfo);
    }
}
