using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoAPI.Models;

namespace CatalogoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoFilmesController : ControllerBase
    {
        private readonly CatalogoContext _context;

        public CatalogoFilmesController(CatalogoContext context)
        {
            _context = context;
        }

        // GET: api/CatalogoFilmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoFilme>>> GetCatalogoFilmes()
        {
            return await _context.CatalogoFilmes.ToListAsync();
        }

        // GET: api/CatalogoFilmes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoFilme>> GetCatalogoFilme(long id)
        {
            var catalogoFilme = await _context.CatalogoFilmes.FindAsync(id);

            if (catalogoFilme == null)
            {
                return NotFound();
            }

            return catalogoFilme;
        }

        // PUT: api/CatalogoFilmes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoFilme(long id, CatalogoFilme catalogoFilme)
        {
            if (id != catalogoFilme.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogoFilme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoFilmeExists(id))
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

        // POST: api/CatalogoFilmes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogoFilme>> PostCatalogoFilme(CatalogoFilme catalogoFilme)
        {
            _context.CatalogoFilmes.Add(catalogoFilme);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCatalogoFilme), new { id = catalogoFilme.Id }, catalogoFilme);
        }

        // DELETE: api/CatalogoFilmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogoFilme(long id)
        {
            var catalogoFilme = await _context.CatalogoFilmes.FindAsync(id);
            if (catalogoFilme == null)
            {
                return NotFound();
            }

            _context.CatalogoFilmes.Remove(catalogoFilme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogoFilmeExists(long id)
        {
            return _context.CatalogoFilmes.Any(e => e.Id == id);
        }
    }
}
