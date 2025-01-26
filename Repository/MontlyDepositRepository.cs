using api.Data;
using api.Dtos.MonthlyDeposit;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MontlyDepositRepository : IMonthlyDepositRepository
    {
        private readonly ApplicationDBContext _context;

        public MontlyDepositRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<MonthlyDeposit> CreateAsync(MonthlyDeposit montlyDepositmodel)
        {
            await _context.MonthlyDeposit.AddAsync(montlyDepositmodel);
            await _context.SaveChangesAsync();
            return montlyDepositmodel;
        }

        public async Task<MonthlyDeposit?> DeleteAsync(int id)
        {
            var model = await _context.MonthlyDeposit.FirstOrDefaultAsync(x => x.Id == id);
            if(model == null)
            {
                return null;
            }

            _context.MonthlyDeposit.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<MonthlyDeposit>> GetAllAsync()
        {
            return await _context.MonthlyDeposit.ToListAsync();
        }

        public async Task<MonthlyDeposit?> GetByIdAsync(int id)
        {
            return await _context.MonthlyDeposit.FindAsync(id);
        }

        public async Task<MonthlyDeposit?> UpdateAsync(int id, UpdateMonthlyDeposittRequestDto monthlyDepositDto)
        {
            var existingDeposit = await _context.MonthlyDeposit.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDeposit == null)
            {
                return null;
            }

            existingDeposit.UserId = monthlyDepositDto.UserId;
            existingDeposit.Amount = monthlyDepositDto.Amount;
            existingDeposit.Month = monthlyDepositDto.Month;
            existingDeposit.Year = monthlyDepositDto.Year;
            existingDeposit.DepositedDate = monthlyDepositDto.DepositedDate;
            await _context.SaveChangesAsync();
            return existingDeposit;
        }
    }
}
