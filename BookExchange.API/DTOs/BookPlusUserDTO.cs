namespace BookExchange.API.DTOs
{
    public class BookPlusUserInfoDTO
    {
        public string Username { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public bool WantExchange { get; set; }
        public string Thumbnail { get; set; }
    }
}