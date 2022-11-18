using CarsAPI.EF;
using CarsAPI.Interfaces;
using CarsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly IMakeRepository _makeRepository;

        public MakesController(IMakeRepository makeRepository)
        {
            _makeRepository = makeRepository;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllMakes()
        {
            var makes = _makeRepository.GetAllMakes();

            return Ok(makes);
        }

        [Route("GetMake/{id}")]
        [HttpGet]
        public IActionResult GetMake(int id)
        {
            var make = _makeRepository.GetMake(id);

            if(make is null)
            {
                return BadRequest("No Data was Found"); 
            }
            return Ok(make); 
        }
        [Route("AddMake")]
        [HttpPost]
        public IActionResult Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("No Make Specified."); 
            }

            var make = _makeRepository.CreateMake(name); 

            return Ok(make);
        }
    }
}
