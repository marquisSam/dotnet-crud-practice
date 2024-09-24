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
                var item = await _itemServices.CreateAsync(request);
                return Ok(item);
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
                return Ok( items );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}