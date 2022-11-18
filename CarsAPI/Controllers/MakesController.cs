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

        [Route("GetAllMakes")]
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

        [Route("AddNewMake")]
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

        [Route("UpdateMake/{id}")]
        [HttpPut]
        public IActionResult UpdateMake(int id, string name)
        {
            var updateMake = _makeRepository.GetMake(id); 
            if(updateMake is null)
            {
                return BadRequest("Model Not Found!"); 
            }
            if(string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("No Make Specified"); 
            }
      
            var updatedMake = _makeRepository.UpdateMake(updateMake, name);

            return Ok(updatedMake); 
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var make = _makeRepository.GetMake(id); 

            if(make is null)
            {
                return BadRequest("Model Not Found");
            }

             _makeRepository.DeleteMake(make); 

            return Ok(GetAllMakes());
        }
    }
}
