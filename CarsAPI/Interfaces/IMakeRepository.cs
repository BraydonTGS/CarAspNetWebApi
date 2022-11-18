using CarsAPI.EF;

namespace CarsAPI.Interfaces
{
    public interface IMakeRepository
    {
        ICollection<Make> GetAllMakes(); 
        Make GetMake(int id);

        Make CreateMake(string name);

        Make UpdateMake(Make make, string name); 
    }
}
