using CarsAPI.EF;

namespace CarsAPI.Interfaces
{
    public interface IUserRepository
    {
       IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User CreateNewUser(string firstName, string lastName, string email, string username);
       User UpdateUser(User user, string first, string last, string email, string username); 
    }
}
