using ItemsApi.Contracts;
using ItemsApi.Models;

namespace ItemsApi.Interface
{
    public interface IBagServices
    {
        Task<IEnumerable<Bag>> GetAll();
        Task<Bag> GetByIdAsync(Guid id);
        Task<Bag> CreateAsync(CreateBagRequest request);
        Task<Bag> UpdateAsync(Guid id, UpdateBagRequest request);
        Task<Bag> DeleteAsync(Guid id);
        Task<Bag> AddItemsToBagAsync(Guid bagId, Guid itemId);
        Task<Bag> RemoveItemFromBagAsync(Guid bagId, Guid itemId);
    }
}