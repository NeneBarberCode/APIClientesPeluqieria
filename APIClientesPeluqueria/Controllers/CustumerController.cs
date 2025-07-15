using APIClientesPeluqueria.Context;
using APIClientesPeluqueria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIClientesPeluqueria.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class CustumerController : ControllerBase
    {
        private readonly ApplicationContext context;

        public CustumerController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await context.Customers.ToListAsync();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var exist = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                return NotFound();
            }
            return Ok(exist);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Customer customer)
        {
            context.Add(customer);

            await context.SaveChangesAsync();

            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest("Los IDs deben coincidir.");
            }

            await context.SaveChangesAsync();
            return NoContent(); 
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Customers.FindAsync(id);
            if (exist == null)
            {
                return NotFound();
            }
            context.Remove(exist);
            await context.SaveChangesAsync();
            return NoContent();

        }

    }
}
