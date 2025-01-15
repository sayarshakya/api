using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Data;
using Microsoft.AspNetCore.Mvc;

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
            var amounts = _context.Amount.ToList();
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
    }
}