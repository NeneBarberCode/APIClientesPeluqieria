using APIClientesPeluqueria.Context;
using APIClientesPeluqueria.DTOs;
using APIClientesPeluqueria.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIClientesPeluqueria.Controllers
{
    [Route("api/cortes")]
    [ApiController]
    public class HairCutController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public HairCutController(ApplicationContext _context, IMapper mapper) 
        {
            context = _context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HaircutDTO>>> Gethaircuts()
        {
            var haircut = await context.hairCuts.ToListAsync();
            var haircurDTO = mapper.Map<IEnumerable<HaircutDTO>>(haircut);

            return Ok(haircurDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HaircutsWithCustomers>> Get(int id)
        {
          var haircut = await context.hairCuts
                .Include(x => x.Customers)
                .ThenInclude(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (haircut == null)
            {
                return NotFound();
            }
          var haircutDTO = mapper.Map<HaircutsWithCustomers>(haircut);
            return Ok(haircutDTO);   
        }

        [HttpPost]
        public async Task<ActionResult> Post(HaircutDTO haircutDTO)
        {

            var hairCut = mapper.Map<HairCut>(haircutDTO);

            context.Add(hairCut);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Gethaircuts), new { hairCut.Name, hairCut.Cost });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, HairCut hairCut)
        {
            
            if (id != hairCut.Id)
            {

                return BadRequest("Los IDs deben coincidir");
            }

            context.Update(hairCut);
            await context.SaveChangesAsync();   
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.hairCuts.FirstOrDefaultAsync(x => x.Id == id);

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
