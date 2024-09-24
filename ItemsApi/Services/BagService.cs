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
        public Task<Bag> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
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
                _logger.LogError(ex, "An error occurred while creating the Bag.");
                throw new Exception("An error occurred while creating the Bag.");
            }
            return bag;
        }
        public Task<Bag> UpdateAsync(Guid id, UpdateBagRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<Bag> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<Bag> AddItemsToBagAsync(Guid bagId, Guid itemId)
        {
            throw new NotImplementedException();
        }
        public Task<Bag> RemoveItemFromBagAsync(Guid bagId, Guid itemId)
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