namespace BookExchange.API.DTOs
{
    public class UsersbooksDTO
    {
        public string Username { get; set; }
        public string BookTitle { get; set; }
        public bool WantExchange { get; set; }
        public bool WantGet { get; set; }

    }
}