using HurtowniaAPI.Dto.Użytkownik;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HurtowniaAPI.Services
{
    public class KontoService : IKontoService
    {
        private readonly UserManager<Użytkownik> _userManager;
        private readonly SignInManager<Użytkownik> _signInManager;

        public KontoService(UserManager<Użytkownik> userManager, SignInManager<Użytkownik> signInManager)
        { 
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> PostKonto(UżytkownikFullDto dto)
        {
            Użytkownik user = new()
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Imię = dto.Imię,
                Nazwisko = dto.Nazwisko,
                PhoneNumber = dto.NumerTel,
                PESEL = dto.PESEL,
                Firma = dto.Firma
            };
            var result = await _userManager.CreateAsync(user, dto.Hasło);
            if (result.Succeeded)
            {
                var użytkownik = await _userManager.FindByNameAsync(user.UserName);
                var result2 = await _userManager.AddToRoleAsync(user, dto.Rola);
                if (result2.Succeeded)
                {
                    var result3 = await _userManager.AddClaimsAsync(user, new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, użytkownik.Id),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, dto.Rola)
                    });
                    return result3;
                }
                else
                {
                    return result2;
                }
            }
            else
            {
                return result;
            }
        }

        public async Task<string> GetRole(string username)
        {
            var użytkownik = await _userManager.FindByNameAsync(username);
            var result = await _userManager.GetRolesAsync(użytkownik);
            return result.First();
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult?> Login(LoginDto dto)
        {
            Użytkownik user = await _userManager.FindByNameAsync(dto.UserName);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user, dto.Hasło, dto.Pamiętaj, false);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<List<UżytkownikFullDto>> GetPracownicy()
        {
            List<UżytkownikFullDto> pracownicy = new();
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, "Pracownik")) 
                {
                    pracownicy.Add(new UżytkownikFullDto()
                    {
                        Email = user.Email,
                        Imię = user.Imię,
                        Nazwisko = user.Nazwisko,
                        NumerTel = user.PhoneNumber,
                        Id = user.Id,
                        Hasło = "",
                        UserName = "",
                        Rola = ""
                    });
                }
            }
            return pracownicy;
        }

        public async Task<UżytkownikFullDto> GetKonto(string id)
        {
            Użytkownik user = await _userManager.FindByIdAsync(id);
            var role = await _userManager.GetRolesAsync(user);
            UżytkownikFullDto dto = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Imię = user.Imię,
                Nazwisko = user.Nazwisko,
                Hasło = "",
                NumerTel = user.PhoneNumber,
                Firma = user.Firma,
                PESEL = user.PESEL,
                Rola = role.First()
            };
            return dto;
        }

        public async Task<IdentityResult> PutKonto(string id, UżytkownikDto dto)
        {
            Użytkownik user = await _userManager.FindByIdAsync(id);
            user.Email = dto.Email;
            user.PESEL = dto.PESEL;
            user.Nazwisko = dto.Nazwisko;
            user.PhoneNumber = dto.NumerTel;
            user.Imię = dto.Imię;
            user.Firma = dto.Firma;
            IdentityResult result = await _userManager.UpdateAsync(user);
            return result;
        }

        public async Task<IdentityResult> PutHasło(string id, HasłoDto hasło)
        {
            Użytkownik user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.ChangePasswordAsync(user, hasło.StareHasło, hasło.NoweHasło);
            return result;
        }

        public async Task<IdentityResult?> PutRefresh(string username, string token)
        {
            var użytkownik = await _userManager.FindByNameAsync(username);
            użytkownik.RefreshToken = token;
            użytkownik.RefreshTime = DateTime.Now.AddDays(7);
            var result = await _userManager.UpdateAsync(użytkownik);
            return result;
        }

        public async Task<StatusCodeResult> DeleteKonto(string kontoId)
        {
            var użytkownik = await _userManager.FindByIdAsync(kontoId);
            if (użytkownik == null) 
            {
                return new NotFoundResult();
            }

            await _userManager.DeleteAsync(użytkownik);

            return new NoContentResult();
        }

    }
}
