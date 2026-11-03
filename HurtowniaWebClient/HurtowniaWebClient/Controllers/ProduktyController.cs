using HurtowniaWebClient.Models;
using HurtowniaWebClient.Models.Produkty;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HurtowniaWebClient.Controllers
{
    public class ProduktyController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        private readonly string _url = "https://localhost:7250/api/Produkt/";
        private readonly string _url2 = "https://localhost:7250/api/Zdjęcie/";
        private const string JWT = "jwToken";

        public ProduktyController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<IActionResult> Produkty()
        {
            List<Produkt>? produkty = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.GetAsync(_url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    produkty = JsonConvert.DeserializeObject<List<Produkt>>(response);
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
            return View(produkty);
        }

        public async Task<IActionResult> Produkty_Klient()
        {
            List<Produkt>? produkty = new();
            using (var httpClient = new HttpClient())
            {
                using var result = await httpClient.GetAsync(_url + "Klient");
                string response = await result.Content.ReadAsStringAsync();
                produkty = JsonConvert.DeserializeObject<List<Produkt>>(response);
            }
            return View(produkty);
        }

        public ViewResult GetProdukt() => View();

        [HttpPost]
        public async Task<IActionResult> GetProdukt(int id)
        {
            var produkt = new ProduktDetails();
            if (Request.Headers["Referer"].ToString() == "https://localhost:7204/Produkty/GetProdukt") 
            {
                ViewBag.Redirect = true;
            }
            else
            {
                ViewBag.Redirect = false;
            }
            using (var httpClient = new HttpClient())
            {
                using var result = await httpClient.GetAsync(_url + id);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    produkt = JsonConvert.DeserializeObject<ProduktDetails>(response);
                }
                else
                {
                    ViewBag.StatusCode = result.StatusCode;
                }
            }
            return View(produkt);
        }

        public ViewResult AddProdukt() => View();

        [HttpPost]
        public async Task<IActionResult> AddProdukt(ProduktFile produkt)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _environment.WebRootPath;
                produkt.Zdjęcia = new List<Zdjęcie>();
                for (int i = 0; i < produkt.Pliki.Count; i++) 
                {
                    produkt.Zdjęcia.Add(new Zdjęcie() 
                    { 
                        Id = 0, 
                        Nazwa = "" 
                    }
                    );
                }
                var zip = produkt.Zdjęcia.Zip(produkt.Pliki);
                var zdjęcia = new List<Zdjęcie>();
                foreach (var (First, Second) in zip)
                {
                    string fileName = Path.GetFileNameWithoutExtension(Second.FileName);
                    string extension = Path.GetExtension(Second.FileName);
                    First.Nazwa = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    zdjęcia.Add(First);
                }
                ProduktFull dto = new()
                {
                    Id = 0,
                    VAT = produkt.VAT,
                    Cena = produkt.Cena,
                    Ilość = produkt.Ilość,
                    Nazwa = produkt.Nazwa,
                    Opis = produkt.Opis,
                    Zdjęcia = zdjęcia
                };
                string? jwToken = Request.Cookies[JWT];
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.PostAsync(_url, 
                    new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
                    );
                if (result.IsSuccessStatusCode)
                {
                    foreach (var (First, Second) in zip)
                    {
                        string path = Path.Combine(wwwRootPath + "/images/", First.Nazwa);
                        using var fileStream = new FileStream(path, FileMode.Create);
                        await Second.CopyToAsync(fileStream);
                    }
                    return RedirectToAction("Produkty");
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
            return View();
        }

        public async Task<IActionResult> UpdateProdukt(int id)
        {
            ProduktUpdate produkt = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url + "Full/" + id);
                if (result.IsSuccessStatusCode)
                {
                    string apiResponse = await result.Content.ReadAsStringAsync();
                    ProduktFull? dto = JsonConvert.DeserializeObject<ProduktFull>(apiResponse);
                    if (dto != null)
                    {
                        produkt.Id = dto.Id;
                        produkt.Opis = dto.Opis;
                        produkt.Zdjęcia = dto.Zdjęcia;
                        produkt.Cena = dto.Cena;
                        produkt.Ilość = dto.Ilość;
                        produkt.Nazwa = dto.Nazwa;
                        produkt.VAT = dto.VAT;
                        produkt.Pliki = new();
                        produkt.DoUsun = "";
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
            return View(produkt);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProdukt(ProduktUpdate produkt)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _environment.WebRootPath;
                var zdjęcia = new List<Zdjęcie>();
                IEnumerable<(Zdjęcie First, IFormFile Second)>? zip = null;
                produkt.Zdjęcia = new();
                if (produkt.Pliki != null) 
                {
                    for (int i = 0; i < produkt.Pliki.Count; i++)
                    {
                        produkt.Zdjęcia.Add(new Zdjęcie() { Id = 0, Nazwa = "" });
                    }
                    zip = produkt.Zdjęcia.Zip(produkt.Pliki);
                    foreach (var (First, Second) in zip)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(Second.FileName);
                        string extension = Path.GetExtension(Second.FileName);
                        First.Nazwa = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        zdjęcia.Add(First);
                    }
                }
                ProduktUpdate2 dto = new()
                {
                    Id = produkt.Id,
                    Opis = produkt.Opis,
                    VAT = produkt.VAT,
                    Cena = produkt.Cena,
                    Ilość = produkt.Ilość,
                    Nazwa = produkt.Nazwa,
                    Zdjęcia = zdjęcia,
                    DoUsun = new()
                };
                if (produkt.DoUsun != null) 
                {
                    var s = produkt.DoUsun.Split('*');
                    foreach (var s2 in s)
                    {
                        if (s2 != "")
                        {
                            dto.DoUsun.Add(s2);
                        }
                    }
                }
                string? jwToken = Request.Cookies[JWT];
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.PutAsync(_url + dto.Id, 
                    new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
                    );
                if (result.IsSuccessStatusCode)
                {
                    if (zip != null)
                    {
                        foreach (var (First, Second) in zip)
                        {
                            string path = Path.Combine(wwwRootPath + "/images/", First.Nazwa);
                            using var fileStream = new FileStream(path, FileMode.Create);
                            await Second.CopyToAsync(fileStream);
                        }
                    }
                    foreach (var zdjęcie in dto.DoUsun)
                    {
                        System.IO.File.Delete(wwwRootPath + "/images/" + zdjęcie);
                    }
                    return RedirectToAction("Produkty");
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
            return View(produkt);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProdukt(int id)
        {
            string? jwToken = Request.Cookies[JWT];
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
            using var result = await httpClient.GetAsync(_url2 + "Produkt/" + id);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                List<Zdjęcie>? zdjęcia = JsonConvert.DeserializeObject<List<Zdjęcie>>(response);
                if (zdjęcia != null)
                {
                    using var result2 = await httpClient.DeleteAsync(_url + id);
                    if (result2.StatusCode == HttpStatusCode.NoContent)
                    {
                        string wwwRootPath = _environment.WebRootPath;
                        foreach (var zdjęcie in zdjęcia)
                        {
                            System.IO.File.Delete(wwwRootPath + "/images/" + zdjęcie.Nazwa);
                        }
                        return RedirectToAction("Produkty");
                    }
                    else
                    {
                        if (result2.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            return Redirect("/Account/Refresh");
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
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

    }
}
