using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Data;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Amount;
using api.Mappers;

namespace api.Controllers
{
    [Route("api/amount")]
    [ApiController]
    public class AmountController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public AmountController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var amounts = _context.Amount.ToList()
            .Select(s => s.ToAmountDto());
            return Ok(amounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var amount = _context.Amount.Find(id);
            if(amount == null)
            {
                return NotFound();
            }

            return Ok(amount);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAmountRequestDto amountDto)
        {
            var amountModel = amountDto.ToAmountFromCreateDTO();
            _context.Amount.Add(amountModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = amountModel.Id}, amountModel.ToAmountDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var amountModel = _context.Amount.FirstOrDefault(x => x.Id == id);
            if(amountModel == null)
            {
                return NotFound();
            }
            _context.Amount.Remove(amountModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}