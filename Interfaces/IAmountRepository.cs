using api.Dtos.Amount;
using api.Models;

namespace api.Interfaces
{
    public interface IAmountRepository
    {
        Task<List<Amount>> GetAllAsync();
        Task<Amount?> GetByIdAsync(int id);
        Task<Amount> CreateAsync(Amount amountModel);
        Task<Amount?> UpdateAsync(int id, UpdateAmountRequestDto amountDto);
        Task<Amount?> DeleteAsync(int id);
    }
}
