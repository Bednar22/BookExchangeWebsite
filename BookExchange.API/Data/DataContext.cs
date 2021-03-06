using Microsoft.EntityFrameworkCore;
using BookExchange.API.Models;

namespace BookExchange.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersBooks> UsersBooks { get; set; }
    }
}