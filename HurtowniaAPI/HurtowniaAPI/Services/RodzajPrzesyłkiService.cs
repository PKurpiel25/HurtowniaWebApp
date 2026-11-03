using HurtowniaAPI.Dto;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Services
{
    public class RodzajPrzesyłkiService : IRodzajPrzesyłkiService
    {
        private readonly HurtowniaDbContext _context;

        public RodzajPrzesyłkiService(HurtowniaDbContext context)
        {
            _context = context;
        }

        public IQueryable<RodzajPrzesyłkiDto> GetRodzajePrzesyłki()
        {
            var rodzaje = from r in _context.RodzajePrzesyłki select new RodzajPrzesyłkiDto() { Id = r.Id, Koszt = r.Koszt, Nazwa = r.Nazwa };
            return rodzaje;
        }

        public async ValueTask<RodzajPrzesyłkiDto?> GetRodzajPrzesyłki(int id)
        {
            var rodzaj = await _context.RodzajePrzesyłki.Select(r => new RodzajPrzesyłkiDto() { Id = r.Id, Koszt = r.Koszt, Nazwa = r.Nazwa }).SingleOrDefaultAsync(r => r.Id == id);
            return rodzaj;
        }

    }
}
