using ItemsApi.Interface;
using ItemsApi.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace ItemsApi.Controllers.Items
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices _itemServices;
        private readonly ILogger<ItemsController> _logger;
        public ItemsController(IItemServices itemServices, ILogger<ItemsController> logger)
        {
            _itemServices = itemServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemAsync(CreateDndItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var item = await _itemServices.CreateAsync(request);
                return Ok(new { message = $"Successfully created item.", data = item });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            try
            {
                var items = await _itemServices.GetAllItems();
                return Ok(new { message = $"Successfully retrieved items.", data = items });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting items");
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteItemAsync(Guid id)
        {
            try
            {
                var item = await _itemServices.DeleteAsync(id);
                _logger.LogInformation($"Item deleted successfully: {item.Name}");
                return Ok(new { message = $"Successfully deleted item {item.Name}.", data = item });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting item: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}