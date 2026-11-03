using DinkToPdf;
using DinkToPdf.Contracts;
using HurtowniaWebClient.Models.Konto;
using HurtowniaWebClient.Models.Produkty;
using HurtowniaWebClient.Models.Zamówienia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HurtowniaWebClient.Controllers
{
    public class ZamówieniaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IConverter _converter;

        private readonly string _url = "https://localhost:7250/api/Zamówienie/";
        private readonly string _url2 = "https://localhost:7250/api/Konto/";
        private const string SessionKeyName = "_Koszyk";
        private const string JWT = "jwToken";

        public ZamówieniaController(IConfiguration configuration, IConverter converter)
        {
            _configuration = configuration;
            _converter = converter;
        }

        public async Task<IActionResult> Zamówienia()
        {
            List<ZamówienieSingle>? zamówienia = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    zamówienia = JsonConvert.DeserializeObject<List<ZamówienieSingle>>(response);
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
            return View(zamówienia);
        }

        public async Task<IActionResult> Zamówienia_Klient()
        {
            List<ZamówienieSingleKlient>? zamówienia = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url2 + "UserId");
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    using var result2 = await httpClient.GetAsync(_url + "Klient/" + response);
                    if (result2.IsSuccessStatusCode)
                    {
                        string response2 = await result2.Content.ReadAsStringAsync();
                        zamówienia = JsonConvert.DeserializeObject<List<ZamówienieSingleKlient>>(response2);
                    }
                    else
                    {
                        if (result2.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            return Redirect("/Account/Refresh");
                        }
                        else
                        {
                            return NotFound();
                        }
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
                        return NotFound();
                    }
                }
            }
            return View(zamówienia);
        }

        public ViewResult GetZamówienie() => View();

        [HttpPost]
        public async Task<IActionResult> GetZamówienie(int id)
        {
            ZamówienieDetails? zamówienie = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url + id);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    zamówienie = JsonConvert.DeserializeObject<ZamówienieDetails>(response);
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
            return View(zamówienie);
        }

        public ViewResult GetZamówienie_Klient() => View();

        [HttpPost]
        public async Task<IActionResult> GetZamówienie_Klient(int id)
        {
            ZamówienieDetailsKlient? zamówienie = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.GetAsync(_url + id + "/Klient");
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    zamówienie = JsonConvert.DeserializeObject<ZamówienieDetailsKlient>(response);
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
            return View(zamówienie);
        }

        [HttpPost]
        public async Task<IActionResult> AddZamówienie(ZamówienieDetailsExtra form)
        {
            var jwToken = Request.Cookies[JWT];
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
            var result = await httpClient.GetAsync(_url2 + "UserId");
            if (result.IsSuccessStatusCode) 
            {
                string response = await result.Content.ReadAsStringAsync();
                ZamówienieFull zamówienie = new()
                {
                    Id = form.Id,
                    KlientId = response,
                    Koszt = form.Koszt,
                    Produkty = new(),
                    RodzajPrzesyłkiId = form.RodzajPrzesyłkiId,
                    RodzajPłatnościId = form.RodzajPłatnościId,
                    Adres = form.AdresUlica + "," + form.AdresMiasto + "," + form.AdresKod
                };
                List<ProduktKoszyk>? produkty;
                var sesja = HttpContext.Session.GetString(SessionKeyName);
                if (sesja != null)
                {
                    produkty = JsonConvert.DeserializeObject<List<ProduktKoszyk>>(sesja);
                    if (produkty != null)
                    {
                        foreach (var produkt in produkty)
                        {
                            zamówienie.Produkty.Add(produkt);
                        }
                        using var result2 = await httpClient.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(zamówienie), Encoding.UTF8, "application/json"));
                        if (result2.StatusCode == HttpStatusCode.Created)
                        {
                            HttpContext.Session.SetString(SessionKeyName, "");
                            return Redirect("/Home/Index");
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

        public async Task<IActionResult> GenerujPDF(int id)
        {
            string html = $@"
                <!DOCTYPE html>
                <html>
	            <head>
		        <title>Faktura</title>
	            </head>
	            <body>
		        <table style=""margin: 0 auto; background-color: beige; border: 1px solid black"">
			    <tr>
				<td colspan=""4"" style=""text-align: center; background-color: gray;""><h1>Faktura</h1></td>
			    </tr>
			    <tr>
                <td colspan=""4"" style=""text-align: center; background-color: lightgray;""><h3>" + 
                _configuration["Firma:Nazwa"] + $@"</h3></td>
			    </tr>
			    <tr>
				<td style=""width: 25%"">" + _configuration["Firma:AdresUlica"] + $@"</td>
				<td style=""width: 25%""></td>
				<th style=""width: 25%"">Data:</td>
				<td style=""width: 25%"">" + DateTime.Now.ToShortDateString() + $@"</td>
			    </tr>
			    <tr>
				<td style=""width: 25%"">" + _configuration["Firma:AdresReszta"] + $@"</td>
			    </tr>
			    <tr>
				<td><b>Telefon: </b>" + _configuration["Firma:NumerTel"] + $@"</td>
			    </tr>
			    <tr>
				<td><b>Fax: </b>" + _configuration["Firma:Fax"] + $@"</td>
			    </tr>
			    <tr>
				<td>" + _configuration["Firma:StronaInt"] + $@"</td>
			    </tr>";
            var jwToken = Request.Cookies[JWT];
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
            var result = await httpClient.GetAsync(_url2);
            if (result.IsSuccessStatusCode) 
            {
                string response = await result.Content.ReadAsStringAsync();
                var użytkownik = JsonConvert.DeserializeObject<Użytkownik>(response);
                var result2 = await httpClient.GetAsync(_url + id + "/Adres");
                if (result2.IsSuccessStatusCode)
                {
                    string response2 = await result2.Content.ReadAsStringAsync();
                    var adres = JsonConvert.DeserializeObject<ZamówienieAdres>(response2);
                    if (użytkownik != null && adres != null) 
                    {
                        html += $@"
                            <tr>
                            <td colspan=""4"" style=""background-color: gray;""><h3>Dane osobowe</h3></td>
			                </tr>
			                <tr>
                            <td>" + użytkownik.Imię + " " + użytkownik.Nazwisko + $@"</td>
			                </tr>
			                <tr>
                            <td>" + użytkownik.Firma + $@"</td>
			                </tr>
			                <tr>
                            <td>" + adres.AdresUlica + $@"</td>
			                </tr>
			                <tr>
				            <td>" + adres.AdresMiasto + ", " + adres.AdresKod + $@"</td>
			                </tr>
			                <tr>
				            <td>" + użytkownik.NumerTel + $@"</td>
			                </tr>
                            <tr style=""background-color: gray;"">
                            <th>Nazwa prod.</th>
				            <th>Ilość prod.</th>
				            <th>Cena za jednostkę</th>
				            <th>Koszt</th>
			                </tr>";
                        var result3 = await httpClient.GetAsync(_url + id + "/Faktura");
                        if (result3.IsSuccessStatusCode)
                        {
                            string response3 = await result3.Content.ReadAsStringAsync();
                            ZamówienieInvoice? zamówienie = JsonConvert.DeserializeObject<ZamówienieInvoice>(response3);
                            if (zamówienie != null)
                            {
                                foreach (var produkt in zamówienie.Produkty)
                                {
                                    decimal koszt = produkt.Ilość * produkt.Cena;
                                    html += $@"
                                        <tr>
                                        <td style=""border: 1px solid white;"">" + produkt.Nazwa + $@"</td>
				                        <td style=""border: 1px solid white;"">" + produkt.Ilość + $@"</td>
				                        <td style=""border: 1px solid white;"">" + 
                                        produkt.Cena.ToString().Remove(produkt.Cena.ToString().Length - 2, 2)
                                        .Insert(produkt.Cena.ToString().Length - 2, "zł") + 
                                        $@"</td>
				                        <td style=""border: 1px solid white;"">" + 
                                        koszt.ToString().Remove(koszt.ToString().Length - 2, 2)
                                        .Insert(koszt.ToString().Length - 2, "zł") + 
                                        $@"</td>
                                        </tr>";
                                }
                                html += $@"
                                    <tr>
                                    <th colspan=""3"" style=""text-align: right; background-color: lightgray;"">Koszt przesyłki:</td>
				                    <td style=""border: 1px solid white;"">" + 
                                    zamówienie.KosztPrzesyłki.ToString()
                                    .Insert(zamówienie.KosztPrzesyłki.ToString().Length, "zł") + 
                                    $@"</td>
			                        </tr>
			                        <tr>
                                    <th colspan=""3"" style=""text-align: right; background-color: gray;"">Koszt całkowity:</td>
				                    <th style=""text-align: left; border: 1px solid white;"">" + 
                                    zamówienie.Koszt.ToString()
                                    .Insert(zamówienie.Koszt.ToString().Length, "zł") + 
                                    $@"</td>
			                        </tr>
                                    </table>
                                    </body>
                                    </html>";
                                var globalSettings = new GlobalSettings()
                                {
                                    PaperSize = PaperKind.A4,
                                    Margins = new MarginSettings
                                    {
                                        Top = 25,
                                        Bottom = 25
                                    }
                                };
                                var webSettings = new WebSettings()
                                {
                                    DefaultEncoding = "utf-8"
                                };
                                var headerSettings = new HeaderSettings()
                                {
                                    FontSize = 15,
                                    FontName = "Ariel"
                                };
                                var footerSettings = new FooterSettings()
                                {
                                    FontSize = 12,
                                    FontName = "Ariel"
                                };
                                var objectSettings = new ObjectSettings()
                                {
                                    HtmlContent = html,
                                    HeaderSettings = headerSettings,
                                    FooterSettings = footerSettings,
                                    WebSettings = webSettings
                                };
                                var htmlToPdfDocument = new HtmlToPdfDocument()
                                {
                                    GlobalSettings = globalSettings,
                                    Objects = {
                                        objectSettings
                                    }
                                };
                                var pdfFile = _converter.Convert(htmlToPdfDocument);
                                string fileName = użytkownik.Nazwisko + użytkownik.Imię + "Faktura" + 
                                    new Random().Next(0, 100000);
                                return File(pdfFile, "application/octet-stream", fileName + ".pdf");
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