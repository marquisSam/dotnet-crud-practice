using ItemsApi.Interface;
using ItemsApi.Models;
using ItemsApi.Contracts;
using AutoMapper;
using ItemsApi.AppDataContext;
using Microsoft.EntityFrameworkCore;

namespace ItemsApi.Services
{
    public class BagService : IBagServices
    {
        private readonly ItemDbContext _context;
        private readonly ILogger<BagService> _logger;
        private readonly IMapper _mapper;
        public async Task<IEnumerable<Bag>> GetAll()
        {
            var bags = await _context.Bags.ToListAsync();
            if (bags == null)
            {
                throw new Exception(" No bags found");
            }
            return bags;
        }
        public async Task<Bag> GetByIdAsync(Guid id)
        {
            Console.WriteLine($"meuhhhh {id}. ID type: {id.GetType().Name}");
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                throw new Exception("Bag not found");
            }
            return bag;
        }
        public async Task<Bag> CreateAsync(CreateBagRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var bag = _mapper.Map<Bag>(request);
            bag.CreatedAt = DateTime.UtcNow;
            _context.Bags.Add(bag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Task failed successfully to create the Bag.");
                throw new Exception($"Task failed successfully to create the Bag: {ex.Message}.");
            }
            return bag;
        }
        public async Task<Bag> UpdateAsync(Guid id, UpdateBagRequest request)
        {
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                throw new Exception("Bag not found");
            }
            _mapper.Map(request, bag);
            bag.UpdatedAt = DateTime.UtcNow;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Task failed successfully to update the Bag.");
                throw new Exception($"Task failed successfully to update the Bag: {ex.Message}.");
            }
            return bag;
        }
        public async Task<Bag> DeleteAsync(Guid id)
        {
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                throw new Exception("Bag not found");
            }
            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();
            return bag;
        }


        public Task<Bag> AddItemsToBagAsync(Guid bagId, Guid itemId)
        {
            throw new NotImplementedException();
        }
        public Task<Bag> RemoveItemFromBagAsync(Guid bagId, Guid itemId)
        {
            throw new NotImplementedException();
        }
        public Task<Bag> EmptyBagAsync(Guid bagId)
        {
            throw new NotImplementedException();
        }
        public BagService(ItemDbContext context, ILogger<BagService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
    }
}