using HurtowniaAPI.Dto;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RodzajPrzesyłkiController : ControllerBase
    {
        private readonly IRodzajPrzesyłkiService _service;

        public RodzajPrzesyłkiController(IRodzajPrzesyłkiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Klient")]
        public IQueryable<RodzajPrzesyłkiDto> GetRodzajePrzesyłki()
        {
            return _service.GetRodzajePrzesyłki();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Klient")]
        public async Task<ActionResult<RodzajPrzesyłkiDto>> GetRodzajPrzesyłki(int id)
        {
            var rodzaj = await _service.GetRodzajPrzesyłki(id);

            if(rodzaj == null)
            {
                return NotFound();
            }

            return rodzaj;
        }

    }
}
