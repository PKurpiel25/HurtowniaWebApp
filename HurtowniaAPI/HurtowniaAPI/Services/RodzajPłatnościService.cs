using HurtowniaAPI.Dto;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Services
{
    public class RodzajPłatnościService : IRodzajPłatnościService
    {
        private readonly HurtowniaDbContext _context;

        public RodzajPłatnościService(HurtowniaDbContext context) 
        { 
            _context = context;
        }

        public IQueryable<RodzajPłatnościDto> GetRodzajePłatności()
        {
            var rodzaje = from r in _context.RodzajePłatności select new RodzajPłatnościDto() { Id = r.Id, Nazwa = r.Nazwa };
            return rodzaje;
        }

        public async ValueTask<RodzajPłatnościDto?> GetRodzajPłatności(int id)
        {
            var rodzaj = await _context.RodzajePłatności.Select(
                r => new RodzajPłatnościDto() 
                { 
                    Id = r.Id, 
                    Nazwa = r.Nazwa 
                }
                ).SingleOrDefaultAsync(r => r.Id == id);
            return rodzaj;
        }

    }
}
