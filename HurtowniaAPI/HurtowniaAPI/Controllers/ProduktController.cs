using HurtowniaAPI.Dto.Produkt;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly IProduktService _service;

        public ProduktController(IProduktService service)
        {
            _service = service;
        }

        // GET: api/Produkt
        [HttpGet]
        [Authorize(Roles = "Pracownik")]
        public IQueryable<ProduktDto> GetProdukty()
        {
            return _service.GetProdukty();
        }

        [HttpGet("Klient")]
        [AllowAnonymous]
        public IQueryable<ProduktDto> GetProdukty_Klient()
        {
            return _service.GetProdukty();
        }

        // GET: api/Produkt/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProduktDetailsDto>> GetProdukt(int id)
        {
            var produkt = await _service.GetProdukt(id);

            if (produkt == null)
            {
                return NotFound();
            }

            return produkt;
        }

        [HttpGet("Full/{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<ActionResult<ProduktFullDto>> GetProduktFull(int id)
        {
            var produkt = await _service.GetProduktFull(id);

            if (produkt == null)
            {
                return NotFound();
            }

            return produkt;
        }

        // PUT: api/Produkt/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> PutProdukt(int id, ProduktUpdateDto produkt)
        {
            return await _service.PutProdukt(id, produkt);
        }

        // POST: api/Produkt
        [HttpPost]
        [Authorize(Roles = "Pracownik")]
        public async Task<ActionResult<ProduktFullDto>> PostProdukt(ProduktFullDto produkt)
        {
            await _service.PostProdukt(produkt);

            return CreatedAtAction("GetProdukt", new { id = produkt.Id }, produkt);
        }

        // DELETE: api/Produkt/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> DeleteProdukt(int id)
        {
            return await _service.DeleteProdukt(id);
        }
    }
}