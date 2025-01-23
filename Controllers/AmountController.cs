using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Data;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Amount;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/amount")]
    [ApiController]
    public class AmountController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IAmountRepository _amountRepository;
        public AmountController(ApplicationDBContext context, IAmountRepository amountRepository)
        {
            _context = context;
            _amountRepository = amountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var amounts = await _amountRepository.GetAllAsync();
            var amountDto = amounts.Select(s => s.ToAmountDto());
            return Ok(amountDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var amount = await _amountRepository.GetByIdAsync(id);
            if(amount == null)
            {
                return NotFound();
            }

            return Ok(amount);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAmountRequestDto amountDto)
        {
            var amountModel = amountDto.ToAmountFromCreateDTO();
            await _amountRepository.CreateAsync(amountModel);
            return CreatedAtAction(nameof(GetById), new {id = amountModel.Id}, amountModel.ToAmountDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAmountRequestDto amountDto)
        {

            var amountModel = await _amountRepository.UpdateAsync(id, amountDto);

            if (amountModel == null)
            {
                return NotFound();
            }

            return Ok(amountModel.ToAmountDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var amountModel = await _amountRepository.DeleteAsync(id);
            if(amountModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}