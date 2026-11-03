using HurtowniaAPI.Dto;
using HurtowniaAPI.Dto.Użytkownik;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HurtowniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontoController : ControllerBase
    {
        private readonly IKontoService _kontoService;
        private readonly ITokenService _tokenService;

        public KontoController(IKontoService kontoService, ITokenService tokenService)
        {
            _kontoService = kontoService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostKonto(UżytkownikFullDto dto)
        {
            var result = await _kontoService.PostKonto(dto);
            if (result.Succeeded)
            {
                var result2 = await _kontoService.Login(new LoginDto() { UserName = dto.UserName, Hasło = dto.Hasło, Pamiętaj = false });
                if (result2 != null)
                {
                    if (result2.Succeeded)
                    {
                        var token = new TokenDto
                        {
                            JwToken = await _tokenService.GenerujJwToken(dto.UserName, dto.Rola),
                            RefreshToken = _tokenService.GenerujRefreshToken(),
                            Rola = dto.Rola
                        };
                        if (token.JwToken != null)
                        {
                            return Ok(token);
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
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteKonto(string id)
        {
            return await _kontoService.DeleteKonto(id);
        }

        [HttpGet("Pracownicy")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPracownicy()
        {
            var result = await _kontoService.GetPracownicy();
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Klient,Pracownik,Admin")]
        public async Task<IActionResult> GetKonto()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null) 
            {
                var jwt = _tokenService.DecodeToken(token);
                if (jwt != null) 
                {
                    var id = jwt.Claims.First(t => t.Type == ClaimTypes.NameIdentifier);
                    var result = await _kontoService.GetKonto(id.Value);
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            else 
            { 
                return BadRequest();
            }
        }

        [HttpGet("UserId")]
        [Authorize(Roles = "Klient,Pracownik,Admin")]
        public IActionResult GetId()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null) 
            {
                var jwt = _tokenService.DecodeToken(token);
                if (jwt != null)
                {
                    var login = jwt.Claims.First(t => t.Type == ClaimTypes.NameIdentifier);
                    return Ok(login.Value);
                }
                else
                {
                    return Ok(null);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Klient,Pracownik,Admin")]
        public async Task<IActionResult> PutKonto(string id, UżytkownikDto user)
        {
            var result = await _kontoService.PutKonto(id, user);
            return Ok(result);
        }

        [HttpPut("Hasło/{id}")]
        [Authorize(Roles = "Klient,Pracownik,Admin")]
        public async Task<IActionResult> PutHasło(string id, HasłoDto hasło)
        {
            var result = await _kontoService.PutHasło(id, hasło);
            return Ok(result);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _kontoService.Login(login);
            if (result != null)
            {
                if (result.Succeeded) 
                {
                    var rola = await _kontoService.GetRole(login.UserName);
                    var token = new TokenDto
                    {
                        JwToken = await _tokenService.GenerujJwToken(login.UserName, rola),
                        RefreshToken = _tokenService.GenerujRefreshToken(),
                        Rola = rola
                    };
                    if (token.JwToken != null)
                    {
                        var result2 = await _kontoService.PutRefresh(login.UserName, token.RefreshToken);
                        if (result2 != null)
                        {
                            if (result2.Succeeded)
                            {
                                return Ok(token);
                            }
                            else
                            {
                                return BadRequest("Niepoprawny login lub hasło!");
                            }
                        }
                        else
                        {
                            return BadRequest("Niepoprawny login lub hasło!");
                        }
                    }
                    else
                    {
                        return BadRequest("Niepoprawny login lub hasło!");
                    }
                }
                else
                {
                    return BadRequest("Niepoprawny login lub hasło!");
                }
            }
            else
            {
                return BadRequest("Niepoprawny login lub hasło!");
            }
        }

        [HttpGet("Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _kontoService.Logout();
            return Ok();
        }

        [HttpGet("Auth_Klient")]
        [Authorize(Roles = "Klient")]
        public IActionResult Auth_Klient()
        {
            return Ok();
        }

        [HttpGet("Auth_Pracownik")]
        [Authorize(Roles = "Pracownik")]
        public IActionResult Auth_Pracownik()
        {
            return Ok();
        }

        [HttpGet("Auth_Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Auth_Admin()
        {
            return Ok();
        }


        [HttpPost("Refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken(RefreshDto token)
        {
            bool isCorrect = _tokenService.IsCorrect(token);
            if (isCorrect)
            {
                bool isValid = _tokenService.IsValid(token);
                if (isValid)
                {
                    var result = await _tokenService.GetToken(token);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return NoContent();
            }
        }

    }
}
