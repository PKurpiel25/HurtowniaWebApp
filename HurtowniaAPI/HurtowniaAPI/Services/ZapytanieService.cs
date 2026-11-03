using HurtowniaAPI.Dto.Zapytanie;
using HurtowniaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Services
{
    public class ZapytanieService : IZapytanieService
    {
        private readonly HurtowniaDbContext _context;

        public ZapytanieService(HurtowniaDbContext context)
        {
            _context = context;
        }

        public async Task<StatusCodeResult> DeleteZapytanie(int id)
        {
            var zapytanie = await _context.Zapytania.FindAsync(id);
            if (zapytanie == null)
            {
                return new NotFoundResult();
            }

            _context.Zapytania.Remove(zapytanie);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public IQueryable<ZapytanieSingleDto> GetZapytania()
        {
            var zapytania = from z in _context.Zapytania select new ZapytanieSingleDto() 
            { 
                Id = z.Id, 
                Tytuł = z.Tytuł, 
                ProduktNazwa = z.Produkt.Nazwa, 
                KlientEmail = z.Użytkownik.Email 
            };
            return zapytania;
        }

        public async ValueTask<ZapytanieDetailsDto?> GetZapytanie(int id)
        {
            var zapytanie = await _context.Zapytania.Select(z => new ZapytanieDetailsDto() { Id = z.Id, Tytuł = z.Tytuł, Treść = z.Treść, ProduktNazwa = z.Produkt.Nazwa, KlientEmail = z.Użytkownik.Email }).SingleOrDefaultAsync(z => z.Id == id);
            return zapytanie;
        }

        public async Task PostZapytanie(ZapytanieFullDto dto)
        {
            Zapytanie zapytanie = new() { Id = dto.Id, Tytuł = dto.Tytuł, Treść = dto.Treść, ProduktId = dto.ProduktId, UżytkownikId = dto.KlientId };
            _context.Zapytania.Add(zapytanie);
            await _context.SaveChangesAsync();
        }

        public async Task<StatusCodeResult> PutZapytanie(int id, ZapytanieFullDto dto)
        {
            Zapytanie zapytanie = new() 
            { 
                Id = dto.Id, 
                Tytuł = dto.Tytuł, 
                Treść = dto.Treść, 
                ProduktId = dto.ProduktId, 
                UżytkownikId = dto.KlientId 
            };
            if (id != zapytanie.Id)
            {
                return new BadRequestResult();
            }
            _context.Entry(zapytanie).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZapytanieExists(id))
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

        public bool ZapytanieExists(int id)
        {
            return _context.Zapytania.Any(e => e.Id == id);
        }
    }
}
