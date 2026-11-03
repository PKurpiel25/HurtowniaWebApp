using HurtowniaWebClient.Models;
using HurtowniaWebClient.Models.Produkty;
using HurtowniaWebClient.Models.Zamówienia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HurtowniaWebClient.Controllers
{
    public class KoszykController : Controller
    {
        private readonly string _url = "https://localhost:7250/api/RodzajPrzesyłki/";
        private readonly string _url2 = "https://localhost:7250/api/RodzajPłatności/";
        private readonly string _url3 = "https://localhost:7250/api/Konto/";
        private const string SessionKeyName = "_Koszyk";
        private const string JWT = "jwToken";
        
        [HttpPost]
        public async Task<IActionResult> DodajDoKoszyka(ProduktKoszyk produkt)
        {
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient()) 
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.GetAsync(_url3 + "Auth_Klient");
                if (!result.IsSuccessStatusCode) 
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized) 
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            List<ProduktKoszyk>? produkty;
            var sesja = HttpContext.Session.GetString(SessionKeyName);
            if (sesja != null && sesja != "") 
            {
                produkty = JsonConvert.DeserializeObject<List<ProduktKoszyk>>(sesja);
                if (produkty != null)
                {
                    var wynik = produkty.Find(o => o.Id == produkt.Id);
                    if (wynik != null) 
                    {
                        if ((wynik.Ilość + produkt.Ilość) <= produkt.MaxIlość)
                        {
                            wynik.Ilość += produkt.Ilość;
                        }
                        else
                        {
                            return RedirectPreserveMethod("/Produkty/GetProdukt");
                        }
                    }
                    else
                    {
                        produkty.Add(produkt);
                    }
                    HttpContext.Session.SetString(SessionKeyName, JsonConvert.SerializeObject(produkty));
                    return Redirect("/Produkty/Produkty_Klient");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                produkty = new()
                {
                    produkt
                };
                HttpContext.Session.SetString(SessionKeyName, JsonConvert.SerializeObject(produkty));
                return Redirect("/Produkty/Produkty_Klient");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ZwiększIlość(ProduktKoszyk produkt)
        {
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.GetAsync(_url3 + "Auth_Klient");
                if (!result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            List<ProduktKoszyk>? produkty;
            var sesja = HttpContext.Session.GetString(SessionKeyName);
            if (sesja != null && sesja != "") 
            {
                produkty = JsonConvert.DeserializeObject<List<ProduktKoszyk>>(sesja);
                if (produkty != null)
                {
                    var wynik = produkty.Find(o => o.Id == produkt.Id);
                    if (wynik != null)
                    {
                        if ((wynik.Ilość + produkt.Ilość) <= produkt.MaxIlość) 
                        {
                            wynik.Ilość += produkt.Ilość;
                            HttpContext.Session.SetString(SessionKeyName, JsonConvert.SerializeObject(produkty));
                            return RedirectToAction("Koszyk");
                        }
                        else
                        {
                            return RedirectToAction("Koszyk");
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> ZmniejszIlość(int id)
        {
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.GetAsync(_url3 + "Auth_Klient");
                if (!result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            List<ProduktKoszyk>? produkty;
            var sesja = HttpContext.Session.GetString(SessionKeyName);
            if (sesja != null && sesja != "")
            {
                produkty = JsonConvert.DeserializeObject<List<ProduktKoszyk>>(sesja);
                if (produkty != null)
                {
                    var wynik = produkty.Find(o => o.Id == id);
                    if (wynik != null)
                    {
                        if (wynik.Ilość - 1 > 0) 
                        {
                            wynik.Ilość--;
                            HttpContext.Session.SetString(SessionKeyName, JsonConvert.SerializeObject(produkty));
                            return RedirectToAction("Koszyk");
                        }
                        else
                        {
                            return RedirectToAction("Koszyk");
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> UsuńZKoszyka(int id, decimal suma)
        {
            ProduktLista lista = new()
            {
                Suma = suma
            };
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.GetAsync(_url3 + "Auth_Klient");
                if (!result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            string? sesja = HttpContext.Session.GetString(SessionKeyName);
            if (sesja != null) 
            {
                lista.Produkty = JsonConvert.DeserializeObject<List<ProduktKoszyk>>(sesja);
                if (lista.Produkty != null)
                {
                    ProduktKoszyk? produkt = lista.Produkty.Find(p => p.Id == id);
                    if (produkt != null)
                    {
                        lista.Produkty.Remove(produkt);
                        lista.Suma -= produkt.Cena * produkt.Ilość;
                        HttpContext.Session.SetString(SessionKeyName, JsonConvert.SerializeObject(lista.Produkty));
                        return RedirectToAction("Koszyk");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Koszyk()
        {
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.GetAsync(_url3 + "Auth_Klient");
                if (!result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            string? sesja = HttpContext.Session.GetString(SessionKeyName);
            if (sesja != null) 
            {
                ProduktLista lista = new()
                {
                    Produkty = JsonConvert.DeserializeObject<List<ProduktKoszyk>>(sesja),
                    Suma = 0
                };
                if (lista.Produkty != null)
                {
                    foreach (var produkt in lista.Produkty)
                    {
                        lista.Suma += produkt.Cena * produkt.Ilość;
                    }
                    return View(lista);
                }
                else
                {
                    return View(null);
                }
            }
            else
            {
                return View(null);
            }
        }

        public async Task<IActionResult> Koszyk_Wybór()
        {
            string? jwToken = Request.Cookies[JWT];
            List<ProduktKoszyk>? produkty;
            string? sesja = HttpContext.Session.GetString(SessionKeyName);
            if (sesja != null)
            {
                produkty = JsonConvert.DeserializeObject<List<ProduktKoszyk>>(sesja);
                ZamówienieDetailsExtra zamówienie = new()
                {
                    Koszt = 0
                };
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                    using var result = await httpClient.GetAsync(_url);
                    if (result.IsSuccessStatusCode)
                    {
                        string response = await result.Content.ReadAsStringAsync();
                        var wynik = JsonConvert.DeserializeObject<List<RodzajPrzesyłki>>(response);
                        if (wynik != null)
                        {
                            zamówienie.RodzajePrzesyłki = wynik;
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    else
                    {
                        if (result.StatusCode == HttpStatusCode.Unauthorized) 
                        {
                            return Redirect("/Account/Refresh");
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    using var result2 = await httpClient.GetAsync(_url2);
                    if (result.IsSuccessStatusCode)
                    {
                        string response2 = await result2.Content.ReadAsStringAsync();
                        var wynik2 = JsonConvert.DeserializeObject<List<RodzajPłatności>>(response2);
                        if (wynik2 != null)
                        {
                            zamówienie.RodzajePłatności = wynik2;
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    else
                    {
                        if (result.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            return Redirect("/Account/Refresh");
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                }
                if (produkty != null)
                {
                    foreach (var produkt in produkty)
                    {
                        zamówienie.Koszt += produkt.Cena * produkt.Ilość;
                    }
                    return View(zamówienie);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Koszyk_Podsumowanie(ZamówienieDetailsExtra zamówienie)
        {
            string? jwToken = Request.Cookies[JWT];
            List<ProduktKoszyk>? produkty;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url + zamówienie.RodzajPrzesyłkiId);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    var wynik = JsonConvert.DeserializeObject<RodzajPrzesyłki>(response);
                    if (wynik != null)
                    {
                        zamówienie.Koszt += wynik.Koszt;
                        zamówienie.RodzajPrzesyłkiNazwa = wynik.Nazwa;
                        zamówienie.KosztPrzesyłki = wynik.Koszt;
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                using var result2 = await httpClient.GetAsync(_url2 + zamówienie.RodzajPłatnościId);
                if (result2.IsSuccessStatusCode)
                {
                    string response2 = await result2.Content.ReadAsStringAsync();
                    var wynik2 = JsonConvert.DeserializeObject<RodzajPłatności>(response2);
                    if (wynik2 != null)
                    {
                        zamówienie.RodzajPłatnościNazwa = wynik2.Nazwa;
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            string? sesja = HttpContext.Session.GetString(SessionKeyName);
            if (sesja != null)
            {
                produkty = JsonConvert.DeserializeObject<List<ProduktKoszyk>>(sesja);
                if (produkty != null)
                {
                    zamówienie.Produkty = produkty;
                    return View(zamówienie);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
            
        }

    }
}
