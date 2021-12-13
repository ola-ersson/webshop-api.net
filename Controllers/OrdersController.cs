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
    public class OrdersController : ControllerBase
    {
        private readonly WebshopContext _context;
        private readonly IMapper _mapper;
        public OrdersController(WebshopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Order> orders = await _context.Orders.Include(o => o.OrderRows).ToListAsync();
            List<OrderDTO> orderDTOs = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTOs);
        }

        //GET :id
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
                Order found = await _context.Orders.Include(o => o.OrderRows).FirstOrDefaultAsync(i => i.id == id);
                if(found == null) {
                    return NotFound();
                }
                return Ok(_mapper.Map<OrderDTO>(found));
        }  

        // POST
        [HttpPost]
        public async Task<ActionResult> Post(OrderDTO newOrderDTO)
        {
            Order newOrder = _mapper.Map<Order>(newOrderDTO);
            newOrder.created = DateTime.Now;
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", _mapper.Map<OrderDTO>(newOrder));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Order order)
        {
            if (id != order.id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
            Order order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.id == id);
        }
    }
}
