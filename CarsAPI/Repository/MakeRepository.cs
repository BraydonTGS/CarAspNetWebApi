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

        public Make GetMake(int id)
        {
            return _context.Makes.Where(m => m.MakeId == id).FirstOrDefault(); 
        }

        public Make CreateMake(string makeName)
        {
            Make make = new Make()
            {
                MakeName = makeName,
            }; 

            _context.Makes.Add(make);

            _context.SaveChanges();

            return make;
         
        }

        public Make UpdateMake(Make make, string name)
        {
         
            make.MakeName = name;

            _context.Makes.Attach(make);

            _context.SaveChanges();

            return make;
            
        }
    }
}
