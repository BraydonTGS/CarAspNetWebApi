using CarsAPI.EF;

namespace CarsAPI.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        Task<User> CreateNewUserAsync(string firstName, string lastName, string email, string username);

        User UpdateUser(User user, string first, string last, string email, string username); 
    }
}
