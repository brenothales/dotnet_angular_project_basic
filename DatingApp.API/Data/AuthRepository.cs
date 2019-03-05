using System;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;

    public AuthRepository(DataContext context)
      {
      _context = context;
    }
    public Task<User> Login(string username, string password)
    {
      throw new System.NotImplementedException();
    }

    public async Task<User> Register(User user, string password)
    {
      byte[] passwordHash, passwordSalt;
      createPasswordHash(password, out passwordHash, out passwordSalt);
      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;

      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();

      return user;
    }

    private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using( var hmac = new System.Security.Cryptography.HMACSHA512() )
      {
          passwordHash = hmac.Key;
          passwordSalt = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

      }
    }

    public Task<User> UserExists(string username)
    {
      throw new System.NotImplementedException();
    }
  }
}