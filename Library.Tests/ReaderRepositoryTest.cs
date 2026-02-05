using Library.App.Models.Entities;
using Library.App.Models.Repositories;

namespace Library.Tests
{
    public class ReaderRepositoryTest
    {
        private ReaderRepository _repository;
        private Reader _testReader;

        [SetUp]
        public void Setup()
        {
            _repository = new ReaderRepository();
            _testReader = new Reader()
            {
                Id = 1,
                Name = "test",
                LastName = "test",
                Patronymic = "test",
                Address = "test",
                Birthday = new DateTime(1999, 4, 1)
            };
        }

        [Test]
        public void Add_ValidReader_ShouldBeStoredInRecords()
        {
            _repository.Add(_testReader);
            Assert.That(_repository.Records, Has.Count.EqualTo(1));
            Assert.That(_repository.Records, Does.Contain(_testReader));
        }

        [Test]
        public void Add_DuplicatedReader_ShouldNotBeStored()
        {
            _repository.Add(_testReader);
            _repository.Add(_testReader);
            Assert.That(_repository.Records, Has.Count.EqualTo(1));
            Assert.That(_repository.Records, Does.Contain(_testReader));
        }

        [Test]
        public void Add_Null_ShouldNotBeStored()
        {
            _repository.Add(null);
            Assert.That(_repository.Records, Has.Count.EqualTo(0));
        }

        [Test]
        public void Remove_ValidReader_ShouldBeEmptyRecords()
        {
            _repository.Add(_testReader);
            _repository.Remove(_testReader);
            Assert.That(_repository.Records, Has.Count.EqualTo(0));
            Assert.That(_repository.Records, Does.Not.Contain(_testReader));
        }

        [Test]
        public void Remove_ValidReader_ShouldBeOneRecords()
        {
            _repository.Add(_testReader);
            _repository.Add(new Reader());
            _repository.Remove(_testReader);
            Assert.That(_repository.Records, Has.Count.EqualTo(1));
            Assert.That(_repository.Records, Does.Not.Contain(_testReader));
        }

        [Test]
        public void Remove_Null_RecordsUnchanged()
        {
            _repository.Add(_testReader);
            _repository.Remove(null);
            Assert.That(_repository.Records, Has.Count.EqualTo(1));
        }

        [TestCase("test")]
        [TestCase("Test")]
        [TestCase("TEST")]
        [TestCase("teST")]
        [TestCase("te")]
        [TestCase("Te")]
        [TestCase("es")]
        [TestCase("eS")]
        [TestCase("e")]
        [TestCase("t")]
        [TestCase("s")]
        public void FindReaderByName_VariousInputs_ShouldFindReader(string name)
        {
            _repository.Add(_testReader);
            var reader = _repository.FindReaderByName(name);
            Assert.That(reader, Is.Not.Empty);
        }

        [Test]
        public void FindReaderByName_EmptyString_EmptyList()
        {
            _repository.Add(_testReader);
            var reader = _repository.FindReaderByName(String.Empty).ToList();
            Assert.That(reader, Is.Not.Empty);
        }
    }
}