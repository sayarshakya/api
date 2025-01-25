using api.Data;
using api.Dtos.Amount;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AmountRepository : IAmountRepository
    {
        private readonly ApplicationDBContext _context;
        public AmountRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public async Task<Amount> CreateAsync(Amount amountModel)
        {
            await _context.Amount.AddAsync(amountModel);
            await _context.SaveChangesAsync();
            return amountModel;
        }

        public async Task<Amount?> DeleteAsync(int id)
        {
            var amountModel = await _context.Amount.FirstOrDefaultAsync(x => x.Id == id);
            if (amountModel == null)
            {
                return null;
            }

            _context.Amount.Remove(amountModel);
            await _context.SaveChangesAsync();
            return amountModel;
        }

        public async Task<List<Amount>> GetAllAsync()
        {
            return await _context.Amount.ToListAsync();
        }

        public async Task<Amount?> GetByIdAsync(int id)
        {
            return await _context.Amount.FindAsync(id);
        }

        public async Task<Amount?> UpdateAsync(int id, UpdateAmountRequestDto amountDto)
        {
            var existingAmount = await _context.Amount.FirstOrDefaultAsync(x => x.Id == id);
            if(existingAmount == null)
            {
                return null;
            }

            existingAmount.Name = amountDto.Name;
            existingAmount.Deposit = amountDto.Deposit;
            existingAmount.DepositDate = amountDto.DepositDate;
            await _context.SaveChangesAsync();

            return existingAmount;
        }
    }
}
