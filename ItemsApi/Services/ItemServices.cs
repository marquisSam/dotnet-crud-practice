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
            var todo = await _context.DndItems.ToListAsync();
            if (todo == null)
            {
                throw new Exception(" No Todo items found");
            }
            return todo;
        }
        public Task<DndItem> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<DndItem> CreateAsync(CreateDndItemRequest request)
        {
            try
            {
                var items = _mapper.Map<DndItem>(request);
                items.CreatedAt = DateTime.UtcNow;
                _context.DndItems.Add(items);
                await _context.SaveChangesAsync();
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the DndItem.");
                throw new Exception("An error occurred while creating the DndItem.");
            }
        }
        public Task<DndItem> UpdateAsync(Guid id, UpdateDndItemRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<DndItem> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public ItemServices(ItemDbContext context, ILogger<ItemServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

    }
}