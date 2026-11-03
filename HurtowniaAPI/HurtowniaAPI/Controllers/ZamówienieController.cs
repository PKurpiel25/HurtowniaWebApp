using Microsoft.AspNetCore.Mvc;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services;
using HurtowniaAPI.Dto.Zamówienie;
using Microsoft.AspNetCore.Authorization;

namespace HurtowniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZamówienieController : ControllerBase
    {
        private readonly IZamówienieService _service;

        public ZamówienieController(IZamówienieService service)
        {
            _service = service;
        }

        // GET: api/Zamówienie
        [HttpGet]
        [Authorize(Roles = "Pracownik")]
        public IQueryable<ZamówienieSingleDto> GetZamówienie()
        {
            return _service.GetZamówienia();
        }

        // GET: api/Zamówienie/Klient/5
        [HttpGet("Klient/{id}")]
        [Authorize(Roles = "Klient")]
        public IQueryable<ZamówienieSingleKlientDto> GetZamówienia(string id) 
        {
            return _service.GetZamówienia(id);
        }

        // GET: api/Zamówienie/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<ActionResult<ZamówienieDetailsDto>> GetZamówienie(int id)
        {
            var zamówienie = await _service.GetZamówienie(id);

            if (zamówienie == null)
            {
                return NotFound();
            }

            return zamówienie;
        }

        // GET: api/Zamówienie/5/Klient
        [HttpGet("{id}/Klient")]
        [Authorize(Roles = "Klient")]
        public async Task<ActionResult<ZamówienieDetailsKlientDto>> GetZamówienie_Klient(int id)
        {
            var zamówienie = await _service.GetZamówienie_Klient(id);

            if (zamówienie == null)
            {
                return NotFound();
            }

            return zamówienie;
        }

        [HttpGet("{id}/Faktura")]
        [Authorize(Roles = "Klient")]
        public async Task<ActionResult<ZamówienieInvoiceDto>> GetZamówienie_Faktura(int id)
        {
            var zamówienie = await _service.GetZamówienie_Faktura(id);

            if (zamówienie == null)
            {
                return NotFound();
            }

            return zamówienie;
        }

        [HttpGet("{id}/Adres")]
        [Authorize(Roles = "Klient")]
        public async Task<ActionResult<ZamówienieAdresDto>> GetZamówienie_Adres(int id)
        {
            var adres = await _service.GetZamówienie_Adres(id);

            if (adres == null)
            {
                return NotFound();
            }

            return adres;
        }

        // PUT: api/Zamówienie/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> PutZamówienie(int id, ZamówienieFullDto zamówienie)
        {
            return await _service.PutZamówienie(id, zamówienie);
        }

        // POST: api/Zamówienie
        [HttpPost]
        [Authorize(Roles = "Klient")]
        public async Task<ActionResult<Zamówienie>> PostZamówienie(ZamówienieFullDto zamówienie)
        {
            await _service.PostZamówienie(zamówienie);

            return CreatedAtAction("GetZamówienie", new { id = zamówienie.Id }, zamówienie);
        }

        // DELETE: api/Zamówienie/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> DeleteZamówienie(int id)
        {
            return await _service.DeleteZamówienie(id);
        }
    }
}
