using System;
using System.Text;
using System.Threading.Tasks;
using BookExchange.API.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BookExchange.API.Data
{
    public class AuthRepository : IAuthRepository
    {

        #region  public methods
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> Login(string username, string password)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }


            return user;
        }
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHashAndSalt(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExist(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username)) { return true; }
            return false;
        }

        #endregion

        #region private methods

        /* 
        Method used by Register
        Creates PasswordHash and PasswordSalt to encypt user password
        */
        private void CreatePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var passwordsObject = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = passwordsObject.Key;
                passwordHash = passwordsObject.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /* 
        Method used by Login
        Verifies password inputed by user and comapres every byte with passwordHash in database
        */
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var passwordsObject = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var decriptedHash = passwordsObject.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < decriptedHash.Length; i++)
                {
                    if (decriptedHash[i] != passwordHash[i]) { return false; } // password camparison
                }
                return true;
            }
        }

        #endregion
    }
}