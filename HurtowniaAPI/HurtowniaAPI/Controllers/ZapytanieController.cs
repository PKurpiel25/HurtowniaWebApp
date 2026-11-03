using Microsoft.AspNetCore.Mvc;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services;
using HurtowniaAPI.Dto.Zapytanie;
using Microsoft.AspNetCore.Authorization;

namespace HurtowniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapytanieController : ControllerBase
    {
        private readonly IZapytanieService _service;

        public ZapytanieController(IZapytanieService service)
        {
            _service = service;
        }

        // GET: api/Zapytanies
        [HttpGet]
        [Authorize(Roles = "Pracownik")]
        public IQueryable<ZapytanieSingleDto> GetZapytania()
        {
            return _service.GetZapytania();
        }

        // GET: api/Zapytanies/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<ActionResult<ZapytanieDetailsDto>> GetZapytanie(int id)
        {
            var zapytanie = await _service.GetZapytanie(id);

            if (zapytanie == null)
            {
                return NotFound();
            }

            return zapytanie;
        }

        // PUT: api/Zapytanies/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> PutZapytanie(int id, ZapytanieFullDto zapytanie)
        {
            return await _service.PutZapytanie(id, zapytanie);
        }

        // POST: api/Zapytanies
        [HttpPost]
        [Authorize(Roles = "Klient")]
        public async Task<ActionResult<Zapytanie>> PostZapytanie(ZapytanieFullDto zapytanie)
        {
            await _service.PostZapytanie(zapytanie);

            return CreatedAtAction("GetZapytanie", new { id = zapytanie.Id }, zapytanie);
        }

        // DELETE: api/Zapytanies/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> DeleteZapytanie(int id)
        {
            return await _service.DeleteZapytanie(id);
        }
    }
}
