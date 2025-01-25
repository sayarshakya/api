using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Amount;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Helpers;
using api.Data;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var amounts = await _amountRepository.GetAllAsync();
            var amountDto = amounts.Select(s => s.ToAmountDto());
            return Ok(amountDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var amount = await _amountRepository.GetByIdAsync(id);
            if(amount == null)
            {
                return NotFound();
            }

            return Ok(amount);
        }

        [HttpPost("{AmountId:int}")]
        public async Task<IActionResult> Create([FromBody] CreateAmountRequestDto amountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var amountModel = amountDto.ToAmountFromCreateDTO();
            await _amountRepository.CreateAsync(amountModel);
            return CreatedAtAction(nameof(GetById), new {id = amountModel.Id}, amountModel.ToAmountDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAmountRequestDto amountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var amountModel = await _amountRepository.UpdateAsync(id, amountDto);

            if (amountModel == null)
            {
                return NotFound();
            }

            return Ok(amountModel.ToAmountDto());
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var amountModel = await _amountRepository.DeleteAsync(id);
            if(amountModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}