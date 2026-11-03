using HurtowniaAPI.Dto;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RodzajPłatnościController : ControllerBase
    {
        private readonly IRodzajPłatnościService _service;

        public RodzajPłatnościController(IRodzajPłatnościService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Klient")]
        public IQueryable<RodzajPłatnościDto> GetRodzajePłatności()
        {
            return _service.GetRodzajePłatności();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Klient")]
        public async Task<ActionResult<RodzajPłatnościDto>> GetRodzajPłatności(int id)
        {
            var rodzaj = await _service.GetRodzajPłatności(id);

            if (rodzaj == null)
            {
                return NotFound();
            }

            return rodzaj;
        }
    }
}
