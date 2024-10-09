using ItemsApi.Interface;
using ItemsApi.Models;
using ItemsApi.Contracts;
using AutoMapper;
using ItemsApi.AppDataContext;
using Microsoft.EntityFrameworkCore;

namespace ItemsApi.Services
{
    public class ItemServices : IItemServices
    {
        private readonly ItemDbContext _context;
        private readonly ILogger<ItemServices> _logger;
        private readonly IMapper _mapper;

        public async Task<IEnumerable<DndItem>> GetAllItems()
        {     
            var items = await _context.DndItems.ToListAsync();
            if (items == null)
            {
                throw new Exception(" No items items found");
            }
            return items;
        }
        public Task<DndItem> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<DndItem> CreateAsync(CreateDndItemRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var item = _mapper.Map<DndItem>(request);
            item.CreatedAt = DateTime.UtcNow;
            _context.DndItems.Add(item);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "An error occurred while creating the DndItem.");
                throw new Exception("An error occurred while creating the DndItem.");
            }
            return item;
        }
        public Task<DndItem> UpdateAsync(Guid id, UpdateDndItemRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<DndItem> DeleteAsync(Guid id)
        {
            // throw new NotImplementedException();
            var item = await _context.DndItems.FindAsync(id);
            if (item == null)
            {
                throw new Exception("Item not found");
            }
            _context.DndItems.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public ItemServices(ItemDbContext context, ILogger<ItemServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

    }
}