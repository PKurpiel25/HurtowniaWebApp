using HurtowniaWebClient.Models.Zapytania;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HurtowniaWebClient.Controllers
{
    public class ZapytaniaController : Controller
    {
        private readonly string _url = "https://localhost:7250/api/Zapytanie/";
        private readonly string _url2 = "https://localhost:7250/api/Konto/";
        private const string JWT = "jwToken";

        public async Task<IActionResult> Zapytania()
        {
            List<ZapytanieSingle>? zapytania = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    zapytania = JsonConvert.DeserializeObject<List<ZapytanieSingle>>(response);
                }
                else
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            return View(zapytania);
        }

        public ViewResult GetZapytanie() => View();

        [HttpPost]
        public async Task<IActionResult> GetZapytanie(int id)
        {
            ZapytanieDetails? zapytanie = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url + id);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    zapytanie = JsonConvert.DeserializeObject<ZapytanieDetails>(response);
                }
                else
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Redirect("/Account/Refresh");
                    }
                    else
                    {
                        ViewBag.StatusCode = result.StatusCode;
                    }
                }
            }
            return View(zapytanie);
        }

        public async Task<IActionResult> WyślijZapytanie(int id)
        {
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.GetAsync(_url2 + "Auth_Klient");
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
            ZapytanieFull zapytanie = new()
            {
                ProduktId = id
            };
            return View(zapytanie);
        }

        [HttpPost]
        public async Task<IActionResult> WyślijZapytanie(ZapytanieFull zapytanie)
        {
            string? jwToken = Request.Cookies[JWT];
            zapytanie.Id = 0;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url2 + "UserId");
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    zapytanie.KlientId = response;
                    using var result2 = await httpClient.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(zapytanie), Encoding.UTF8, "application/json"));
                    if (!result2.IsSuccessStatusCode)
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
            return Redirect("/Produkty/Produkty_Klient");
        }

    }
}
