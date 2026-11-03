using HurtowniaAPI.Dto.Produkt;
using HurtowniaAPI.Dto.Zdjęcie;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Services
{
    public class ProduktService : IProduktService
    {
        private readonly HurtowniaDbContext _context;

        public ProduktService(HurtowniaDbContext context)
        {
            _context = context;
        }

        public async Task<StatusCodeResult> DeleteProdukt(int id)
        {
            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt == null)
            {
                return new NotFoundResult();
            }
            produkt.Ilość = 0;
            produkt.Opis = "";
            produkt.Usunięty = true;
            _context.Entry(produkt).State = EntityState.Modified;
            var zdjęcia = from z in _context.Zdjęcia where z.ProduktId == id select new Zdjęcie() 
            { 
                Id = z.Id, 
                Nazwa = z.Nazwa, 
                Produkt = z.Produkt, 
                ProduktId = z.ProduktId 
            };
            foreach (var zdjęcie in zdjęcia)
            {
                _context.Zdjęcia.Remove(zdjęcie);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktExists(id))
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

        public async ValueTask<ProduktDetailsDto?> GetProdukt(int id)
        {
            var zdjęcia = await _context.Zdjęcia.Where(z => z.ProduktId == id).Select(
                z => new ZdjęcieDto() 
                { 
                    Id = z.Id, 
                    Nazwa = z.Nazwa 
                }
                ).ToListAsync();
            var produkt = await _context.Produkty.Select(
                p => new ProduktDetailsDto()
                {
                    Id = p.Id,
                    Cena = p.Cena * (1M + p.VAT),
                    Nazwa = p.Nazwa, Opis = p.Opis,
                    Zdjęcia = zdjęcia,
                    Ilość = p.Ilość
                }
                ).SingleOrDefaultAsync(p => p.Id == id);
            return produkt;
        }

        public async ValueTask<ProduktFullDto?> GetProduktFull(int id)
        {
            var zdjęcia = await _context.Zdjęcia.Where(z => z.ProduktId == id).Select(z => new ZdjęcieDto() { Id = z.Id, Nazwa = z.Nazwa }).ToListAsync();
            var produkt = await _context.Produkty.Select(p => new ProduktFullDto() { Id = p.Id, Cena = p.Cena, Ilość = p.Ilość, Opis = p.Opis, Nazwa = p.Nazwa, VAT = p.VAT, Zdjęcia = zdjęcia }).SingleOrDefaultAsync(p => p.Id == id);
            return produkt;
        }

        public IQueryable<ProduktDto> GetProdukty()
        {
            var produkty = from p in _context.Produkty where p.Usunięty == false select new ProduktDto() { Id = p.Id, Cena = p.Cena * (1M + p.VAT), Nazwa = p.Nazwa };
            return produkty;
        }

        public async Task PostProdukt(ProduktFullDto dto)
        {
            Produkt produkt = new() 
            { 
                Id = dto.Id, 
                Cena = dto.Cena, 
                Nazwa = dto.Nazwa, 
                Opis = dto.Opis, 
                VAT = dto.VAT, 
                Ilość = dto.Ilość 
            };
            await _context.Produkty.AddAsync(produkt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            var produkt2 = await _context.Produkty.OrderBy(o => o.Id).LastAsync();
            foreach (var zdjęcie in dto.Zdjęcia)
            {
                await _context.Zdjęcia.AddAsync(new Zdjęcie() 
                { 
                    Id = zdjęcie.Id, 
                    Nazwa = zdjęcie.Nazwa, 
                    ProduktId = produkt2.Id 
                }
                );
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }

        public bool ProduktExists(int id)
        {
            return _context.Produkty.Any(e => e.Id == id);
        }

        public async Task<StatusCodeResult> PutProdukt(int id, ProduktUpdateDto dto)
        {
            Produkt produkt = new() 
            { 
                Id = dto.Id, 
                Cena = dto.Cena, 
                Nazwa = dto.Nazwa, 
                Opis = dto.Opis, 
                VAT = dto.VAT, 
                Ilość = dto.Ilość 
            };
            if (id != produkt.Id)
            {
                return new BadRequestResult();
            }
            _context.Entry(produkt).State = EntityState.Modified;
            foreach (var item in dto.Zdjęcia)
            {
                Zdjęcie zdjęcie = new() 
                { 
                    Id = item.Id, 
                    Nazwa = item.Nazwa, 
                    ProduktId = produkt.Id 
                };
                _context.Zdjęcia.Add(zdjęcie);
            }
            foreach (var item in dto.DoUsun)
            {
                Zdjęcie zdjęcie = _context.Zdjęcia.First(z => z.Nazwa == item);
                _context.Zdjęcia.Remove(zdjęcie);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktExists(id))
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
    }
}
