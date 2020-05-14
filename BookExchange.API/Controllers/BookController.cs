using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookExchange.API.Data;
using BookExchange.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookExchange.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;
        public BookController(DataContext context)
        {
            _context = context;

        }

        [AllowAnonymous]
        [HttpGet("userbooks/{userid}")]
        public ActionResult<IEnumerable<Book>> GetBooks(string title)
        {
            var books = from b in _context.Books
                        where b.Title.Equals(title)
                        select b;
            return Ok(books);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            return book;
        }


        // [AllowAnonymous]
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetBook(int id)
        // {
        //     var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        //     return Ok(book);
        // }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTitle(int id, [FromBody] Book book)
        {
            var data = await _context.Books.FindAsync(id);
            data.Title = book.Title;
            _context.Books.Update(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var data = await _context.Books.FindAsync(id);

            if (data == null)
            {
                return NoContent();
            }

            _context.Books.Remove(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }
    }
}
