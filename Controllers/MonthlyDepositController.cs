using api.Data;
using api.Dtos.Amount;
using api.Dtos.MonthlyDeposit;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/monthly")]
    [ApiController]
    public class MonthlyDepositController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMonthlyDepositRepository _monthlyDepositRepository;

        public MonthlyDepositController(ApplicationDBContext context, IMonthlyDepositRepository monthlyDepositRepository)
        {
            _context = context;
            _monthlyDepositRepository = monthlyDepositRepository;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deposits = await _monthlyDepositRepository.GetAllAsync();
            var depositDto = deposits.Select(d => d.ToMonthlyDepositDto());
            return Ok(depositDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deposit = await _monthlyDepositRepository.GetByIdAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }

            return Ok(deposit);
        }

        [HttpPost("{Deposit:int}")]
        public async Task<IActionResult> Create([FromBody] CreateMonthlyDepositRequestDto depositDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var depositModel = depositDto.ToMontlyDepositFromCreateDTO();
            await _monthlyDepositRepository.CreateAsync(depositModel);
            return CreatedAtAction(nameof(GetById), new { id = depositModel.Id }, depositModel.ToMonthlyDepositDto());
        }
    }
}
