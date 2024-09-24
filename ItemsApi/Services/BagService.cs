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
        public Task<IEnumerable<Bag>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Bag> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<Bag> CreateAsync(CreateBagRequest request)
        {
            throw new NotImplementedException();
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