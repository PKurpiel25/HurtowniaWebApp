using HurtowniaAPI.Dto.Produkt;
using HurtowniaAPI.Dto.Zamówienie;
using HurtowniaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Services
{
    public class ZamówienieService : IZamówienieService
    {
        private readonly HurtowniaDbContext _context;

        public ZamówienieService(HurtowniaDbContext context)
        {
            _context = context;
        }

        public async Task<StatusCodeResult> DeleteZamówienie(int id)
        {
            var zamówienie = await _context.Zamówienia.FindAsync(id);
            if (zamówienie == null)
            {
                return new NotFoundResult();
            }

            _context.Zamówienia.Remove(zamówienie);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public IQueryable<ZamówienieSingleDto> GetZamówienia()
        {
            var zamówienia = from z in _context.Zamówienia select new ZamówienieSingleDto() { Id = z.Id, Koszt = z.Koszt, RodzajPrzesyłkiNazwa = z.RodzajPrzesyłki.Nazwa, RodzajPłatnościNazwa = z.RodzajPłatności.Nazwa, KlientEmail = z.Użytkownik.Email };
            return zamówienia;
        }

        public IQueryable<ZamówienieSingleKlientDto> GetZamówienia(string id)
        {
            var zamówienia = from z in _context.Zamówienia where z.Użytkownik.Id == id select new ZamówienieSingleKlientDto() { Id = z.Id, Koszt = z.Koszt, RodzajPrzesyłkiNazwa = z.RodzajPrzesyłki.Nazwa, RodzajPłatnościNazwa = z.RodzajPłatności.Nazwa };
            return zamówienia;
        }

        public async ValueTask<ZamówienieDetailsDto?> GetZamówienie(int id)
        {
            List<Tuple<int, int>> produktyIdIlość = new();
            List<ProduktDto> produkty = new();
            foreach (var prod in _context.ProduktyZamówienia.Where(p => p.ZamówienieId == id)) 
            {
                produktyIdIlość.Add(new(prod.ProduktId, prod.Ilość));
            }
            foreach (var produktIdIlość in produktyIdIlość)
            {
                var produkt = await _context.Produkty.FirstOrDefaultAsync(p => p.Id == produktIdIlość.Item1);
                if (produkt != null)
                {
                    produkty.Add(new ProduktDto() { Id = produkt.Id, Cena = (produkt.Cena * produkt.VAT) + produkt.Cena, Nazwa = produkt.Nazwa, Ilość = produktIdIlość.Item2 });
                }
            }
            var zamówienie = await _context.Zamówienia.SingleOrDefaultAsync(p => p.Id == id);
            if (zamówienie != null)
            {
                string[] adres = zamówienie.Adres.Split(',');
                var result = await _context.Zamówienia.Select(z => new ZamówienieDetailsDto() { Id = z.Id, Koszt = z.Koszt, RodzajPrzesyłkiNazwa = z.RodzajPrzesyłki.Nazwa, RodzajPłatnościNazwa = z.RodzajPłatności.Nazwa, KlientEmail = z.Użytkownik.Email, Produkty = produkty, KosztPrzesyłki = z.RodzajPrzesyłki.Koszt, AdresUlica = adres[0], AdresMiasto = adres[1], AdresKod = adres[2] }).SingleOrDefaultAsync(z => z.Id == id);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async ValueTask<ZamówienieDetailsKlientDto?> GetZamówienie_Klient(int id)
        {
            List<Tuple<int, int>> produktyIdIlość = new();
            List<ProduktDto> produkty = new();
            foreach (var prod in _context.ProduktyZamówienia.Where(p => p.ZamówienieId == id))
            {
                produktyIdIlość.Add(new(prod.ProduktId, prod.Ilość));
            }
            foreach (var produktIdIlość in produktyIdIlość)
            {
                var produkt = await _context.Produkty.FirstOrDefaultAsync(p => p.Id == produktIdIlość.Item1);
                if (produkt != null)
                {
                    produkty.Add(new ProduktDto() { Id = produkt.Id, Cena = (produkt.Cena * produkt.VAT) + produkt.Cena, Nazwa = produkt.Nazwa, Ilość = produktIdIlość.Item2 });
                }
            }
            var zamówienie = await _context.Zamówienia.SingleOrDefaultAsync(p => p.Id == id);
            if (zamówienie != null)
            {
                string[] adres = zamówienie.Adres.Split(',');
                var result = await _context.Zamówienia.Select(z => new ZamówienieDetailsKlientDto() { Id = z.Id, Koszt = z.Koszt, RodzajPrzesyłkiNazwa = z.RodzajPrzesyłki.Nazwa, RodzajPłatnościNazwa = z.RodzajPłatności.Nazwa, Produkty = produkty, KosztPrzesyłki = z.RodzajPrzesyłki.Koszt, AdresUlica = adres[0], AdresMiasto = adres[1], AdresKod = adres[2] }).SingleOrDefaultAsync(z => z.Id == id);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async ValueTask<ZamówienieInvoiceDto?> GetZamówienie_Faktura(int id)
        {
            List<Tuple<int, int>> produktyIdIlość = new();
            List<ProduktDto> produkty = new();
            foreach (var prod in _context.ProduktyZamówienia)
            {
                produktyIdIlość.Add(new(prod.ProduktId, prod.Ilość));
            }
            foreach (var produktIdIlość in produktyIdIlość)
            {
                var produkt = await _context.Produkty.FirstOrDefaultAsync(p => p.Id == produktIdIlość.Item1);
                if (produkt != null)
                {
                    produkty.Add(new ProduktDto() { Id = produkt.Id, Cena = (produkt.Cena * produkt.VAT) + produkt.Cena, Nazwa = produkt.Nazwa, Ilość = produktIdIlość.Item2 });
                }
            }
            var zamówienie = await _context.Zamówienia.Select(z => new ZamówienieInvoiceDto() { Id = z.Id, Koszt = z.Koszt, Produkty = produkty, KosztPrzesyłki = z.RodzajPrzesyłki.Koszt }).SingleOrDefaultAsync(z => z.Id == id);
            return zamówienie;
        }

        public async ValueTask<ZamówienieAdresDto?> GetZamówienie_Adres(int id)
        {
            var zamówienie = await _context.Zamówienia.SingleOrDefaultAsync(p => p.Id == id);
            if (zamówienie != null) 
            {
                string[] adres = zamówienie.Adres.Split(',');
                var dto = new ZamówienieAdresDto() { AdresUlica = adres[0], AdresMiasto = adres[1], AdresKod = adres[2] };
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task PostZamówienie(ZamówienieFullDto dto)
        {
            Zamówienie zamówienie = new() { Id = dto.Id, Koszt = dto.Koszt, RodzajPrzesyłkiId = dto.RodzajPrzesyłkiId, RodzajPłatnościId = dto.RodzajPłatnościId, UżytkownikId = dto.KlientId, Adres = dto.Adres };
            _context.Zamówienia.Add(zamówienie);
            await _context.SaveChangesAsync();
            int id = _context.Zamówienia.OrderBy(z => z.Id).Last().Id;
            List<ProduktDto> produktyIlość = new();
            foreach (var produkt in dto.Produkty) 
            {
                produktyIlość.Add(produkt);
            }
            foreach (var produktIlość in produktyIlość) 
            {
                _context.ProduktyZamówienia.Add(new() { ProduktId = produktIlość.Id, ZamówienieId = id, Ilość = produktIlość.Ilość });
                var produkt = await _context.Produkty.FirstOrDefaultAsync(o => o.Id == produktIlość.Id);
                if (produkt != null) 
                {
                    produkt.Ilość -= produktIlość.Ilość;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<StatusCodeResult> PutZamówienie(int id, ZamówienieFullDto dto)
        {
            Zamówienie zamówienie = new() { Id = dto.Id, Koszt = dto.Koszt, RodzajPrzesyłkiId = dto.RodzajPrzesyłkiId, RodzajPłatnościId = dto.RodzajPłatnościId, UżytkownikId = dto.KlientId };
            if (id != zamówienie.Id)
            {
                return new BadRequestResult();
            }

            _context.Entry(zamówienie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamówienieExists(id))
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

        public bool ZamówienieExists(int id)
        {
            return _context.Zamówienia.Any(e => e.Id == id);
        }

    }
}
