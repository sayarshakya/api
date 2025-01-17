using api.Dtos.Amount;
using api.Models;

namespace api.Mappers
{
    public static class AmountMappers
    {
        public static AmountDto ToAmountDto(this Amount amountModel)
        {
            return new AmountDto
            {
                Id = amountModel.Id,
                Name = amountModel.Name,
                Deposit = amountModel.Deposit,
                DepositDate = amountModel.DepositDate
            };
        }

        public static Amount ToAmountFromCreateDTO(this CreateAmountRequestDto amountDto)
        {
            return new Amount
            {
                Name = amountDto.Name,
                Deposit = amountDto.Deposit,
                DepositDate = amountDto.DepositDate
            };
        }
    }
}
