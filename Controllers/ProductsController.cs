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
    public class ProductsController : ControllerBase
    {
        private readonly WebshopContext _context;
        private readonly IMapper _mapper;
        public ProductsController(WebshopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Product> products = await _context.Products.ToListAsync();
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return Ok(productDTOs);
        }

        //GET :id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
                Product found = await _context.Products.FindAsync(id);
                if(found == null) {
                    return NotFound();
                }
                return Ok(_mapper.Map<ProductDTO>(found));
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Post(ProductDTO newProductDTO)
        {
            Product newProduct = _mapper.Map<Product>(newProductDTO);
            newProduct.added = DateTime.Now;
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", _mapper.Map<ProductDTO>(newProduct));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.id == id);
        }
    }
}
