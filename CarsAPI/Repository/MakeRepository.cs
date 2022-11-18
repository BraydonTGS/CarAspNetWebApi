using CarsAPI.EF;
using CarsAPI.Interfaces;

namespace CarsAPI.Repository
{
    public class MakeRepository : IMakeRepository
    {
        private readonly CarDbContext _context;

        public MakeRepository(CarDbContext context)
        {
            _context= context;
        }
        public ICollection<Make> GetAllMakes()
        {
            return _context.Makes.ToList(); 
        }
    }
}
