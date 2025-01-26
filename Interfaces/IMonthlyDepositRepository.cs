using api.Dtos.Amount;
using api.Dtos.MonthlyDeposit;
using api.Models;

namespace api.Interfaces
{
    public interface IMonthlyDepositRepository
    {
        Task<List<MonthlyDeposit>> GetAllAsync();
        Task<MonthlyDeposit?> GetByIdAsync(int id);
        Task<MonthlyDeposit> CreateAsync(MonthlyDeposit montlyDepositmodel);
        Task<MonthlyDeposit?> UpdateAsync(int id, UpdateMonthlyDeposittRequestDto monthlyDepositDto);
        Task<MonthlyDeposit?> DeleteAsync(int id);
    }
}
