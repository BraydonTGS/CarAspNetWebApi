using CarsAPI.Interfaces;
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

        [HttpGet]
        public IActionResult GetAllMakes()
        {
            var makes = _makeRepository.GetAllMakes();

            return Ok(makes);
        }
    }
}
