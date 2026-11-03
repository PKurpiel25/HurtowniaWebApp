using HurtowniaWebClient.Models.Konto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HurtowniaWebClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _url = "https://localhost:7250/api/Konto/";
        private const string JWT = "jwToken";
        private const string refresh = "refreshToken";
        private const string rola = "rola";

        public ViewResult Rejestracja() => View();

        [HttpPost]
        public async Task<IActionResult> Rejestracja(Rejestracja dane)
        {
            if (ModelState.IsValid)
            {
                Użytkownik użytkownik = new()
                {
                    Id = "",
                    Email = dane.Email,
                    Hasło = dane.Hasło,
                    Imię = dane.Imię,
                    UserName = dane.Login,
                    Nazwisko = dane.Nazwisko,
                    NumerTel = dane.NumerTel,
                    PESEL = dane.PESEL,
                    Firma = dane.Firma,
                    Rola = "Klient"
                };
                using var httpClient = new HttpClient();
                var result = await httpClient.PostAsync(_url, 
                    new StringContent(JsonConvert.SerializeObject(użytkownik), Encoding.UTF8, "application/json")
                    );
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<Token>(response);
                    if (token != null)
                    {
                        Response.Cookies.Append(JWT, token.JwToken, new CookieOptions() 
                        { 
                            Expires = DateTime.Now.AddMinutes(1) 
                        }
                        );
                        Response.Cookies.Append(refresh, token.RefreshToken, new CookieOptions() 
                        { 
                            Expires = DateTime.Now.AddDays(7) 
                        }
                        );
                        Response.Cookies.Append(rola, token.Rola, new CookieOptions() 
                        { 
                            Expires = DateTime.Now.AddDays(7) 
                        }
                        );
                        return Redirect("/Home/Index");
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
            return View(dane);
        }

        public ViewResult AddKonto() => View();

        [HttpPost]
        public async Task<IActionResult> AddKonto(Użytkownik użytkownik)
        {
            string? jwToken = Request.Cookies[JWT];
            użytkownik.Id = "";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
            var result = await httpClient.GetAsync(_url + "Auth_Admin");
            if (!result.IsSuccessStatusCode)
            {
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Refresh");
                }
                else
                {
                    return BadRequest();
                }
            }
            var result2 = await httpClient.PostAsync(_url,
                    new StringContent(JsonConvert.SerializeObject(użytkownik), Encoding.UTF8, "application/json")
                    );
            string response = await result2.Content.ReadAsStringAsync();
            if (result2.IsSuccessStatusCode)
            {
                return RedirectToAction("Pracownicy");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteKonto(string kontoId)
        {
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                using var result = await httpClient.DeleteAsync(_url + kontoId);
                if (!result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            return RedirectToAction("Pracownicy");
        }

        public async Task<IActionResult> Pracownicy()
        {
            List<Użytkownik>? pracownicy = new();
            string? jwToken = Request.Cookies[JWT];
            using (var httpClient = new HttpClient()) 
            {
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.GetAsync(_url + "Pracownicy");
                if (result.IsSuccessStatusCode) 
                {
                    string response = await result.Content.ReadAsStringAsync();
                    pracownicy = JsonConvert.DeserializeObject<List<Użytkownik>>(response);
                }
                else
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized) 
                    {
                        return RedirectToAction("Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            return View(pracownicy);
        }

        public async Task<IActionResult> Konto()
        {
            string? jwToken = Request.Cookies[JWT];
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
            var result = await httpClient.GetAsync(_url);
            if (result.IsSuccessStatusCode) 
            {
                string response = await result.Content.ReadAsStringAsync();
                var użytkownik = JsonConvert.DeserializeObject<Użytkownik>(response);
                if (użytkownik != null)
                {
                    return View(użytkownik);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Refresh");
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        public async Task<IActionResult> Update()
        {
            string? jwToken = Request.Cookies[JWT];
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
            var result = await httpClient.GetAsync(_url);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                var użytkownik = JsonConvert.DeserializeObject<Użytkownik>(response);
                if (użytkownik != null)
                {
                    return View(użytkownik);
                }
                else
                {
                    return Redirect("/Home/Index");
                }
            }
            else
            {
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Refresh");
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Użytkownik użytkownik)
        {
            string? jwToken = Request.Cookies[JWT];
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
            var result = await httpClient.PutAsync(_url + użytkownik.Id, new StringContent(JsonConvert.SerializeObject(użytkownik), Encoding.UTF8, "application/json"));
            string response = await result.Content.ReadAsStringAsync();
            var wynik = JsonConvert.DeserializeObject<IdentityResult>(response);
            if (wynik != null)
            {
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Konto");
                }
                else
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("Refresh");
                    }
                    else
                    {
                        foreach (IdentityError error in wynik.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View(użytkownik);
        }

        public async Task<IActionResult> ZmieńHasło()
        {
            string? jwToken = Request.Cookies[JWT];
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
            var result = await httpClient.GetAsync(_url + "UserId");
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                return View(new Hasło() { Id = response });
            }
            else
            {
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Refresh");
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> ZmieńHasło(Hasło hasło)
        {
            if (ModelState.IsValid)
            {
                string? jwToken = Request.Cookies[JWT];
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new(JwtBearerDefaults.AuthenticationScheme, jwToken);
                var result = await httpClient.PutAsync(_url + "Hasło/" + hasło.Id, new StringContent(JsonConvert.SerializeObject(hasło), Encoding.UTF8, "application/json"));
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Logout");
                }
                else
                {
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("Refresh");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            return View(hasło);
        }

        public IActionResult Login()
        {
            Login login = new();
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                using var httpClient = new HttpClient();
                var result = await httpClient.PostAsync(_url + "Login", 
                    new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json")
                    );
                string response = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var token = JsonConvert.DeserializeObject<Token>(response);
                    if (token != null)
                    {
                        Response.Cookies.Append(JWT, token.JwToken, new CookieOptions() 
                        { 
                            Expires = DateTime.Now.AddMinutes(1) 
                        }
                        );
                        if (login.Pamiętaj)
                        {
                            Response.Cookies.Append(refresh, token.RefreshToken, new CookieOptions() 
                            { 
                                Expires = DateTime.Now.AddDays(7) 
                            }
                            );
                            Response.Cookies.Append(rola, token.Rola, new CookieOptions() 
                            { 
                                Expires = DateTime.Now.AddDays(7) 
                            }
                            );
                        }
                        else
                        {
                            Response.Cookies.Append(refresh, token.RefreshToken);
                            Response.Cookies.Append(rola, token.Rola);
                        }
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(login.UserName), response);
                }
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            using var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(_url + "Logout");
            if (result.IsSuccessStatusCode) 
            {
                Response.Cookies.Delete(JWT);
                Response.Cookies.Delete(refresh);
                Response.Cookies.Delete(rola);
            }
            return Redirect("/Home/Index");
        }

        public async Task<IActionResult> Refresh()
        {
            var token = Request.Cookies[refresh];
            if (token == null)
            {
                return RedirectToAction("Login");
            }
            Refresh dto = new()
            {
                Token = token
            };
            using var httpClient = new HttpClient();
            var result = await httpClient.PostAsync(_url + "Refresh", 
                new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
                );
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                Response.Cookies.Append(JWT, response, new CookieOptions() 
                { 
                    Expires = DateTime.Now.AddMinutes(1) 
                }
                );
                return Redirect(Request.Headers["Referer"].ToString());
                
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}
