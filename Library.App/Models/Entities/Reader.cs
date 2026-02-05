namespace Library.App.Models.Entities
{
    public class Reader : Person
    {
        public int Id { get; set; }

        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }
}
