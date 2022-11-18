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
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(user => user.UserId == id).FirstOrDefault(); 
        }
    }
}
