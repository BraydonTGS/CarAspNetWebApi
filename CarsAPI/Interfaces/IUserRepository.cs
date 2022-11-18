using CarsAPI.EF;

namespace CarsAPI.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id); 
    }
}
