using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebShopAPIdotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderRowsController : ControllerBase
    {
        private readonly WebshopContext _context;
        private readonly IMapper _mapper;
        public OrderRowsController(WebshopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<OrderRow> orderrows = await _context.OrderRows.ToListAsync();
            List<OrderRowDTO> orderrowDTOs = _mapper.Map<List<OrderRowDTO>>(orderrows);
            return Ok(orderrowDTOs);
        }

        //GET :id
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderRow>> GetById(int id)
        {
                OrderRow found = await _context.OrderRows.FindAsync(id);
                if(found == null) {
                    return NotFound();
                }
                return Ok(_mapper.Map<OrderRowDTO>(found));
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Post(OrderRowDTO newOrderRowDTO)
        {
            OrderRow newOrderRow = _mapper.Map<OrderRow>(newOrderRowDTO);
            _context.OrderRows.Add(newOrderRow);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", _mapper.Map<OrderRowDTO>(newOrderRow));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrderRow orderrow)
        {
            if (id != orderrow.id)
            {
                return BadRequest();
            }

            _context.Entry(orderrow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderRowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            OrderRow orderrow = await _context.OrderRows.FindAsync(id);
            if (orderrow == null)
            {
                return NotFound();
            }
            _context.OrderRows.Remove(orderrow);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool OrderRowExists(int id)
        {
            return _context.OrderRows.Any(e => e.id == id);
        }
    }
}
