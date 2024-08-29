using ItemsApi.Interface;
using ItemsApi.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace ItemsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices _itemServices;

        public ItemsController(IItemServices itemServices)
        {
            _itemServices = itemServices;
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
                var createdItem = await _itemServices.CreateAsync(request);
                return Ok(new { message = "Item created successfully", item = createdItem });
                // var createdItem = await _itemServices.CreateAsync(request);
                // return CreatedAtAction(nameof(GetItemByIdAsync), new { id = createdItem.Id }, createdItem);
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
                return Ok(new { message = "Items fetched successfully", items = items });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}