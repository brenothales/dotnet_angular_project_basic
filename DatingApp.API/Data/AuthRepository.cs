using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.API.Data{

    public class AuthRepository : IAuthRepository {

        private readonly DataContext _context;

        public AuthRepository(DataContext context) {
            _context = context;
        }

        public async Task<User> Login(string username, string password) {

            User user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return null;

            if (!verifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password) {

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) {

            using (HMACSHA512 hmac = new HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username) {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {

            using (HMACSHA512 hmac = new HMACSHA512(passwordSalt)) {

                byte[] computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; ++i) {
                    if (computeHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}