using BookExchange.API.Data;
using Microsoft.AspNetCore.Mvc;
using BookExchange.API.Models;
using BookExchange.API.DTOs;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System;
using Newtonsoft.Json;
using System.Json;

namespace BookExchange.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersbooksController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        private readonly DataContext _context;
        public UsersbooksController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<UsersBooks> AddUsersBook(UsersbooksDTO usersbookDTO)
        {
            if (_context.Books.Any(x => x.Title == usersbookDTO.BookTitle) == false)
            {
                var bookToCreate = new Book
                {
                    Title = usersbookDTO.BookTitle,
                    Author = GetAuthor(usersbookDTO.BookTitle),
                    WantEchangeAmmount = 0,
                    WantGetAmmount = 0
                };
                if (bookToCreate.Author == null) { return BadRequest("Book doesnt exist"); }
                _context.Books.Add(bookToCreate);
                _context.SaveChanges();
            }

            var book = _context.Books.FirstOrDefault(x => x.Title == usersbookDTO.BookTitle);
            var user = _context.Users.FirstOrDefault(x => x.Username == usersbookDTO.Username);

            var usersbooksToCreate = new UsersBooks
            {
                UserId = user.Id,
                BookId = book.Id,
                WantEchange = usersbookDTO.WantExchange,
                WantGet = usersbookDTO.WantGet
            };
            _context.UsersBooks.Add(usersbooksToCreate);
            _context.SaveChanges();
            if (usersbookDTO.WantExchange == true)
            {
                book.WantEchangeAmmount += 1;
                _context.Books.Update(book);
                _context.SaveChanges();

            }
            if (usersbookDTO.WantGet == true)
            {
                book.WantGetAmmount += 1;
                _context.Books.Update(book);
                _context.SaveChanges();
            }

            return Ok(usersbooksToCreate);
        }

        string GetAuthor(string title)
        {
            string author = null;
            WebClient webClient = new WebClient();
            dynamic result = JsonValue.Parse(webClient.DownloadString("https://www.googleapis.com/books/v1/volumes?q=" + title + "&maxResults=1&keyes&key=AIzaSyCUUzAaqQF7GOO7btRPZLt0-aMqCjkYTZU")).ToString();
            dynamic convertedResult = JsonConvert.DeserializeObject(result);
            if (title != convertedResult.items[0].volumeInfo.title.ToString()) { return null; }
            author = convertedResult.items[0].volumeInfo.authors[0];
            return author;
        }
    } //end of class
}