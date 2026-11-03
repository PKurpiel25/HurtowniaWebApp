using Microsoft.AspNetCore.Mvc;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services;
using HurtowniaAPI.Dto.Zdjęcie;
using Microsoft.AspNetCore.Authorization;

namespace HurtowniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZdjęcieController : ControllerBase
    {
        private readonly IZdjęcieService _service;

        public ZdjęcieController(IZdjęcieService service)
        {
            _service = service;
        }

        // GET: api/Zdjęcie
        [HttpGet]
        [AllowAnonymous]
        public IQueryable<ZdjęcieDto> GetZdjęcia()
        {
            return _service.GetZdjęcia();
        }

        // GET: api/Zdjęcie/5
        [HttpGet("Produkt/{id}")]
        [Authorize(Roles = "Pracownik")]
        public IQueryable<ZdjęcieDto> GetZdjęcia(int id)
        {
            return _service.GetZdjęcia(id);
        }

        // GET: api/Zdjęcie/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ZdjęcieDto>> GetZdjęcie(int id)
        {
            var zdjęcie = await _service.GetZdjęcie(id);

            if (zdjęcie == null)
            {
                return NotFound();
            }

            return zdjęcie;
        }

        // PUT: api/Zdjęcie/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> PutZdjęcie(int id, ZdjęcieFullDto dto)
        {
            return await _service.PutZdjęcie(id, dto);
        }

        // POST: api/Zdjęcie
        [HttpPost]
        [Authorize(Roles = "Pracownik")]
        public async Task<ActionResult<Zdjęcie>> PostZdjęcie(ZdjęcieFullDto dto)
        {
            await _service.PostZdjęcie(dto);
            return CreatedAtAction("GetZdjęcie", new { id = dto.Id }, dto);
        }

        // DELETE: api/Zdjęcie/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> DeleteZdjęcie(int id)
        {
            return await _service.DeleteZdjęcie(id);
        }
    }
}
