using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tienda.Backend.Data;
using Tienda.Shared.Entities;

namespace Tienda.Backend.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
    public class CountriesController: ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() 
        { 
            return Ok(await _context.Countries.AsNoTracking().ToListAsync());        
        }

        /// <summary>
        /// Método para obtener la información de un país por su ID.
        /// </summary>
        /// <remarks>
        /// <b>Este método es muy útil cuando se requiere tener info de un solo país.</b>
        /// &#xD;Si no se suministra un ID o este no existe
        /// &#xD;se recibe una respuesta not found (404).
        /// &#xD;El ID debe ser un valor entero. 
        /// </remarks>
        /// <param name="id">ID del país</param>
        /// <returns>El país si este fue encontrado.</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int id) 
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
