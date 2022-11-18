using CarsAPI.EF;
using CarsAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CarsAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CarDbContext _context;

        public UserRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateNewUserAsync(string firstName, string lastName, string email, string username)
        {
            var newUser = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Username = username
            }; 
            var user = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return user.Entity;
           
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
           return _context.Users.Where(user => user.UserId == id).FirstOrDefault(); 
        }

        public User UpdateUser( User updatedUser, string first, string last, string email, string username)
        {
            updatedUser.FirstName = first;
            updatedUser.LastName = last;
            updatedUser.Email = email;
            updatedUser.Username = username;

            _context.Users.Attach(updatedUser);
            _context.SaveChanges();

            return updatedUser; 
            
        }
    }
}
