
using ItemsApi.Contracts;
using ItemsApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ItemsApi.Controllers.Bags
{
    [ApiController]
    [Route("api/[controller]")]
    public class BagsController : ControllerBase
    {
        private readonly IBagServices _bagServices;

        public BagsController(IBagServices bagServices)
        {
            _bagServices = bagServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBagAsync(CreateBagRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var bag = await _bagServices.CreateAsync(request);
                return Ok(bag);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBagsAsync()
        {
            try
            {
                var bags = await _bagServices.GetAll();
                return Ok( bags );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Console.WriteLine($"Retrieving bag with ID: {id}. ID type: {id.GetType().Name}");
            try
            {
                var bag = await _bagServices.GetByIdAsync(id);
                return Ok(new { message = $"Successfully retrieved bag.", data = bag });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving bag: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
