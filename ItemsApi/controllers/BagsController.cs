
using ItemsApi.Contracts;
using ItemsApi.Interface;
using ItemsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemsApi.Controllers.Bags
{
    [ApiController]
    [Route("api/[controller]")]
    public class BagsController : ControllerBase
    {
        private readonly IBagServices _bagServices;
        private readonly ILogger<BagsController> _logger;
        public BagsController(IBagServices bagServices, ILogger<BagsController> logger)
        {
            _logger = logger;
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
                _logger.LogInformation($"Bag created successfully: {bag.Name}");
                return Ok(new ApiResponse<Bag>(message: $"Successfully created bag.", data: bag));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating bag: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBagsAsync()
        {
            try
            {
                var bags = await _bagServices.GetAll();
                _logger.LogInformation($"Retrieved {bags.Count()} bags.");
                return Ok(new ApiResponse<IEnumerable<Bag>>(message: $"Successfully retrieved bag.", data: bags));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving bags: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            _logger.LogInformation($"Retrieving bag with ID: {id}");
            try
            {
                var bag = await _bagServices.GetByIdAsync(id);
                _logger.LogInformation($"Bag retrieved successfully: {bag.Name}");
                return Ok(new ApiResponse<Bag>(message: $"Successfully retrieved bag.", data: bag));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving bag: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBagAsync(Guid id)
        {
            try
            {
                var bag = await _bagServices.DeleteAsync(id);
                _logger.LogInformation($"Bag deleted successfully: {bag.Name}");
                return Ok(new ApiResponse<Bag>(message: $"Successfully deleted bag {bag.Name}.", data: bag));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting bag: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
