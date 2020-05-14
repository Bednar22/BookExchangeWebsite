namespace BookExchange.API.Models
{
    public class UsersBooks
    {
        public int Id { get; set; }
        public bool WantEchange { get; set; }
        public bool WantGet { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}