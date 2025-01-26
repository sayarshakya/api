using api.Dtos.MonthlyDeposit;
using api.Models;

namespace api.Mappers
{
    public static class MontlyDepositMappers
    {
        public static MontlyDepositDto ToMonthlyDepositDto(this MonthlyDeposit model)
        {
            return new MontlyDepositDto
            {
                Id = model.Id,
                UserId = model.UserId,
                Amount = model.Amount,
                Month = model.Month,
                Year = model.Year,
                DepositedDate = model.DepositedDate
            };
        }

        public static MonthlyDeposit ToMontlyDepositFromCreateDTO(this CreateMonthlyDepositRequestDto montlyDepositDto)
        {
            return new MonthlyDeposit
            {
                UserId = montlyDepositDto.UserId,
                Amount = montlyDepositDto.Amount,
                Month = montlyDepositDto.Month,
                Year = montlyDepositDto.Year,
                DepositedDate = montlyDepositDto.DepositedDate
            };
        }
    }
}
