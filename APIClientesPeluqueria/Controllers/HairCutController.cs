using APIClientesPeluqueria.Context;
using APIClientesPeluqueria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIClientesPeluqueria.Controllers
{
    [Route("api/cortes")]
    [ApiController]
    public class HairCutController : ControllerBase
    {
        private readonly ApplicationContext context;

        public HairCutController(ApplicationContext _context) 
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HairCut>>> Get()
        {
            return await context.hairCuts.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
          var exist = await context.hairCuts.FirstOrDefaultAsync(x => x.Id == id);

            if (exist == null)
            {
                return NotFound();
            }
            context.Add(exist);
            return Ok(exist);   
        }

        [HttpPost]
        public async Task<ActionResult> Post(HairCut hairCut)
        {
            context.Add(hairCut);
            await context.SaveChangesAsync();
            return Created();
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
