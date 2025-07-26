using APIClientesPeluqueria.Context;
using APIClientesPeluqueria.DTOs;
using APIClientesPeluqueria.Models;
using AutoMapper;
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
        private readonly IMapper mapper;

        public CustumerController(ApplicationContext _context, IMapper mapper)
        {
            context = _context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customers = await context.Customers
                .Include(c => c.haircuts)
                .ToListAsync();

            var customerDTO = mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customerDTO);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomersWithHaircutsDTO>> Get(int id)
        {
            var customer = await context.Customers
                .Include(c => c.haircuts)
                .ThenInclude(ch => ch.hairCut)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDTO =  mapper.Map<CustomersWithHaircutsDTO>(customer);

            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Post(CustomerDTO customerDTO)
        {
            var customer = mapper.Map<Customer>(customerDTO);
             
            context.Customers.Add(customer);

            await context.SaveChangesAsync();
            var customerDto = mapper.Map<CustomerDTO>(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customerDto);
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
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            context.Remove(customer);
            await context.SaveChangesAsync();
            return NoContent();

        }

    }
}
