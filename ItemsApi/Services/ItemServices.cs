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
                _logger.LogError(ex, "Task failed sussessfully : creating.");
                throw new Exception($"Task failed sussessfully : {ex.Message}");
            }
            return item;
        }
        public async Task<DndItem> UpdateAsync(Guid id, UpdateDndItemRequest request)
        {
            try
            {
                var item = await _context.DndItems.FindAsync(id);
                if (item == null)
                {
                    throw new Exception("Item not found");
                }

                _mapper.Map(request, item);
                item.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return item;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Task failed sussessfully : updating.");
                throw new Exception($"Task failed sussessfully : {ex.Message}");
            }
        }
        public async Task<DndItem> DeleteAsync(Guid id)
        {
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