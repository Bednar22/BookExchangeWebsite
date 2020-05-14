using BookExchange.API.Data;
using Microsoft.AspNetCore.Mvc;
using BookExchange.API.Models;
using BookExchange.API.DTOs;
using System.Linq;

namespace BookExchange.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersbooksController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersbooksController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<UsersBooks> AddUsersBook(UsersbooksDTO usersbookDTO)
        {
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




    } //end of class
}