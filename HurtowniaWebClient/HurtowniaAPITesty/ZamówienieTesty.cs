using HurtowniaAPI.Controllers;
using HurtowniaAPI.Dto.Produkt;
using HurtowniaAPI.Dto.Zamówienie;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HurtowniaAPITesty
{
    [TestClass]
    public class ZamówienieTesty
    {
        [TestMethod("GetZamówienieTest")]
        public void GetZamówienie()
        {
            var przesyłkaNazwa = "Kurier";
            var przesyłkaKoszt = 25.00M;
            var płatnośćNazwa = "Przy odbiorze";
            var adres1 = "Marszałkowska 30,Warszawa,05-782";
            var adres2 = "Mazowiecka 2,Poznań,60-005";
            var adres3 = "Pocztowa 3,Gdańsk,22-619";
            var koszt1 = 100.50M;
            var koszt2 = 73.25M;
            var koszt3 = 221.00M;
            var userId1 = "7e27871b-38ba-4870-a848-6230bfe672ba";
            var userId2 = "22a7c91d-ac19-5cd0-4b41-75cb2e901ac2";
            var userId3 = "7e27871b-4870-ac19-4b41-6230bfe672ba";
            var imię1 = "Paweł";
            var imię2 = "Anna";
            var imię3 = "Mateusz";
            var nazw1 = "Kowalski";
            var nazw2 = "Cichocka";
            var nazw3 = "Nowak";
            var email1 = "pkowalski@gmail.com";
            var email2 = "acichocka@gmail.com";
            var email3 = "mkowalski@gmail.com";
            var id = 2;
            var cena1 = 25.00M;
            var cena2 = 37.50M;
            var cena3 = 82.00M;
            var ilość1 = 25;
            var ilość2 = 100;
            var ilość3 = 136;
            var nazwa1 = "Produkt1";
            var nazwa2 = "Produkt2";
            var nazwa3 = "Produkt3";
            var opis1 = "Lorem";
            var opis2 = "Ipsum";
            var opis3 = "Docet";
            var vat1 = 0.23M;
            var vat2 = 0.10M;
            var vat3 = 0.00M;
            
            var options = new DbContextOptionsBuilder<HurtowniaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;

            using (var context = new HurtowniaDbContext(options))
            {
                context.RodzajePrzesyłki.Add(new RodzajPrzesyłki() { Id = 1, Nazwa = przesyłkaNazwa, Koszt = przesyłkaKoszt });
                context.RodzajePłatności.Add(new RodzajPłatności() { Id = 1, Nazwa = płatnośćNazwa });
                context.Users.Add(new Użytkownik() { Id = userId1, Email = email1, Imię = imię1, Nazwisko = nazw1 });
                context.Users.Add(new Użytkownik() { Id = userId2, Email = email2, Imię = imię2, Nazwisko = nazw2 });
                context.Users.Add(new Użytkownik() { Id = userId3, Email = email3, Imię = imię3, Nazwisko = nazw3 });
                context.Produkty.Add(new Produkt() { Id = 1, Cena = cena1, Ilość = ilość1, Nazwa = nazwa1, Opis = opis1, VAT = vat1 });
                context.Produkty.Add(new Produkt() { Id = 2, Cena = cena2, Ilość = ilość2, Nazwa = nazwa2, Opis = opis2, VAT = vat2 });
                context.Produkty.Add(new Produkt() { Id = 3, Cena = cena3, Ilość = ilość3, Nazwa = nazwa3, Opis = opis3, VAT = vat3 });
                context.SaveChanges();

                context.Zamówienia.Add(new Zamówienie() { Id = 1, Adres = adres1, Koszt = koszt1, RodzajPrzesyłkiId = 1, RodzajPłatnościId = 1, UżytkownikId = userId1 });
                context.Zamówienia.Add(new Zamówienie { Id = 2, Adres = adres2, Koszt = koszt2, RodzajPrzesyłkiId = 1, RodzajPłatnościId = 1, UżytkownikId = userId2 });
                context.Zamówienia.Add(new Zamówienie() { Id = 3, Adres = adres3, Koszt = koszt3, RodzajPrzesyłkiId = 1, RodzajPłatnościId = 1, UżytkownikId = userId3 });
                context.SaveChanges();

                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 1, ProduktId = 1, Ilość = 10 });
                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 1, ProduktId = 2, Ilość = 2 });
                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 1, ProduktId = 3, Ilość = 7 });
                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 2, ProduktId = 1, Ilość = 4 });
                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 2, ProduktId = 2, Ilość = 6 });
                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 2, ProduktId = 3, Ilość = 8 });
                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 3, ProduktId = 1, Ilość = 3 });
                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 3, ProduktId = 2, Ilość = 4 });
                context.ProduktyZamówienia.Add(new ProduktZamówienie() { ZamówienieId = 3, ProduktId = 3, Ilość = 1 });
                context.SaveChanges();
            }

            using (var context = new HurtowniaDbContext(options))
            {
                var controller = new ZamówienieController(new ZamówienieService(context));
                var zamówienie = controller.GetZamówienie(id).Result.Value;

                Assert.IsNotNull(zamówienie);
                Assert.AreEqual(id, zamówienie.Id);
                Assert.AreEqual(adres2.Split(',')[0], zamówienie.AdresUlica);
                Assert.AreEqual(adres2.Split(',')[1], zamówienie.AdresMiasto);
                Assert.AreEqual(adres2.Split(',')[2], zamówienie.AdresKod);
                Assert.AreEqual(email2, zamówienie.KlientEmail);
                Assert.AreEqual(koszt2, zamówienie.Koszt);
                Assert.AreEqual(przesyłkaKoszt, zamówienie.KosztPrzesyłki);
                Assert.AreEqual(przesyłkaNazwa, zamówienie.RodzajPrzesyłkiNazwa);
                Assert.AreEqual(płatnośćNazwa, zamówienie.RodzajPłatnościNazwa);
                Assert.AreEqual(3, zamówienie.Produkty.Count);
                Assert.AreEqual(3, zamówienie.Produkty[0].Id);
                Assert.AreEqual(2, zamówienie.Produkty[1].Id);
                Assert.AreEqual(1, zamówienie.Produkty[2].Id);
                Assert.AreEqual(nazwa1, zamówienie.Produkty[2].Nazwa);
                Assert.AreEqual(nazwa2, zamówienie.Produkty[1].Nazwa);
                Assert.AreEqual(nazwa3, zamówienie.Produkty[0].Nazwa);
                Assert.AreEqual((cena1 * vat1) + cena1, zamówienie.Produkty[2].Cena);
                Assert.AreEqual((cena2 * vat2) + cena2, zamówienie.Produkty[1].Cena);
                Assert.AreEqual((cena3 * vat3) + cena3, zamówienie.Produkty[0].Cena);
                Assert.AreEqual(4, zamówienie.Produkty[2].Ilość);
                Assert.AreEqual(6, zamówienie.Produkty[1].Ilość);
                Assert.AreEqual(8, zamówienie.Produkty[0].Ilość);
            }

        }

        [TestMethod("PostZamówienieTest")]
        public void PostZamówienie()
        {
            var przesyłkaNazwa = "Kurier";
            var przesyłkaKoszt = 25.00M;
            var płatnośćNazwa = "Przy odbiorze";
            var userId = "7e27871b-38ba-4870-a848-6230bfe672ba";
            var imię = "Paweł";
            var nazw = "Kowalski";
            var email = "pkowalski@gmail.com";
            var adres = "Marszałkowska 30,Warszawa,05-782";
            var koszt = 237.23M;
            var cena1 = 25.00M;
            var cena2 = 37.50M;
            var cena3 = 82.00M;
            var ilość1 = 25;
            var ilość2 = 100;
            var ilość3 = 136;
            var nazwa1 = "Produkt1";
            var nazwa2 = "Produkt2";
            var nazwa3 = "Produkt3";
            var produkty = new List<ProduktDto>() { new ProduktDto() { Id = 1, Cena = cena1, Ilość = ilość1, Nazwa = nazwa1 }, new ProduktDto() { Id = 2, Cena = cena2, Ilość = ilość2, Nazwa = nazwa2 }, new ProduktDto() { Id = 3, Cena = cena3, Ilość = ilość3, Nazwa = nazwa3 } };

            var options = new DbContextOptionsBuilder<HurtowniaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;

            using (var context = new HurtowniaDbContext(options))
            {
                context.RodzajePrzesyłki.Add(new RodzajPrzesyłki() { Id = 1, Nazwa = przesyłkaNazwa, Koszt = przesyłkaKoszt });
                context.RodzajePłatności.Add(new RodzajPłatności() { Id = 1, Nazwa = płatnośćNazwa });
                context.Users.Add(new Użytkownik() { Id = userId, Email = email, Imię = imię, Nazwisko = nazw });
            }

            using (var context = new HurtowniaDbContext(options))
            {
                var controller = new ZamówienieController(new ZamówienieService(context));
                controller.PostZamówienie(new ZamówienieFullDto() { Id = 1, Adres = adres, KlientId = userId, Koszt = koszt, RodzajPrzesyłkiId = 1, RodzajPłatnościId = 1, Produkty= produkty }).Wait();
                var zamówienie = context.Zamówienia.FirstOrDefault();

                Assert.IsNotNull(zamówienie);
                Assert.AreEqual(1, zamówienie.Id);
                Assert.AreEqual(adres, zamówienie.Adres);
                Assert.AreEqual(koszt, zamówienie.Koszt);
                Assert.AreEqual(1, zamówienie.RodzajPrzesyłkiId);
                Assert.AreEqual(1, zamówienie.RodzajPłatnościId);
                Assert.AreEqual(userId, zamówienie.UżytkownikId);
                Assert.IsNotNull(zamówienie.Produkty);
                Assert.AreEqual(3, zamówienie.Produkty.Count);
                Assert.AreEqual(1, zamówienie.Produkty[0].ZamówienieId);
                Assert.AreEqual(1, zamówienie.Produkty[1].ZamówienieId);
                Assert.AreEqual(1, zamówienie.Produkty[2].ZamówienieId);
                Assert.AreEqual(1, zamówienie.Produkty[0].ProduktId);
                Assert.AreEqual(2, zamówienie.Produkty[1].ProduktId);
                Assert.AreEqual(3, zamówienie.Produkty[2].ProduktId);
            }

        }

    }

}
