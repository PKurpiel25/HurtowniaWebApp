using HurtowniaAPI.Dto.Zdjęcie;
using HurtowniaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Services
{
    public class ZdjęcieService : IZdjęcieService
    {
        private readonly HurtowniaDbContext _context;

        public ZdjęcieService(HurtowniaDbContext context)
        {
            _context = context;
        }

        public async Task<StatusCodeResult> DeleteZdjęcie(int id)
        {
            var zdjęcie = await _context.Zdjęcia.FindAsync(id);
            if (zdjęcie == null)
            {
                return new NotFoundResult();
            }

            _context.Zdjęcia.Remove(zdjęcie);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public IQueryable<ZdjęcieDto> GetZdjęcia()
        {
            var zdjęcia = from z in _context.Zdjęcia select new ZdjęcieDto() { Id = z.Id, Nazwa = z.Nazwa };
            return zdjęcia;
        }

        public IQueryable<ZdjęcieDto> GetZdjęcia(int id)
        {
            var zdjęcia = from z in _context.Zdjęcia where z.ProduktId == id select new ZdjęcieDto() { Id = z.Id, Nazwa = z.Nazwa };
            return zdjęcia;
        }

        public async ValueTask<ZdjęcieDto?> GetZdjęcie(int id)
        {
            var zdjęcie = await _context.Zdjęcia.Select(z => new ZdjęcieDto() { Id = z.Id, Nazwa = z.Nazwa }).SingleOrDefaultAsync(z => z.Id == id);
            return zdjęcie;
        }

        public async Task PostZdjęcie(ZdjęcieFullDto dto)
        {
            Zdjęcie zdjęcie = new() 
            { 
                Id = dto.Id, 
                Nazwa = dto.Nazwa, 
                ProduktId = dto.ProduktId 
            };
            _context.Zdjęcia.Add(zdjęcie);
            await _context.SaveChangesAsync();
        }

        public async Task<StatusCodeResult> PutZdjęcie(int id, ZdjęcieFullDto dto)
        {
            Zdjęcie zdjęcie = new() { Id = dto.Id, Nazwa = dto.Nazwa, ProduktId = dto.ProduktId };
            if (id != zdjęcie.Id)
            {
                return new BadRequestResult();
            }

            _context.Entry(zdjęcie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZdjęcieExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return new NoContentResult();
        }

        public bool ZdjęcieExists(int id)
        {
            return _context.Zdjęcia.Any(e => e.Id == id);
        }
    }
}
