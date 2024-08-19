using ItemsApi.Contracts;
using ItemsApi.Models;

namespace ItemsApi.Interface
{
    public interface IItemServices {
        Task<IEnumerable<DndItem>> GetAllItems();
        Task<DndItem> GetByIdAsync(Guid id);
        Task<DndItem> CreateAsync(CreateDndItemRequest request);
        Task<DndItem> UpdateAsync(Guid id, UpdateDndItemRequest request);
        Task<DndItem> DeleteAsync(Guid id);
    }
}