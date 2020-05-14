namespace BookExchange.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int WantEchangeAmmount { get; set; }
        public int WantGetAmmount { get; set; }
        public int Owner { get; set; }
    }
}