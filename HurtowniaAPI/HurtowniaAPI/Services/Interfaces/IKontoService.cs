using HurtowniaAPI.Dto.Użytkownik;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Services.Interfaces
{
    public interface IKontoService
    {
        Task<IdentityResult> PostKonto(UżytkownikFullDto dto);
        Task<Microsoft.AspNetCore.Identity.SignInResult?> Login(LoginDto login);
        Task<string> GetRole(string username);
        Task Logout();
        Task<List<UżytkownikFullDto>> GetPracownicy();
        Task<UżytkownikFullDto> GetKonto(string id);
        Task<StatusCodeResult> DeleteKonto(string kontoId);
        Task<IdentityResult> PutKonto(string id, UżytkownikDto dto);
        Task<IdentityResult> PutHasło(string id, HasłoDto hasło);
        Task<IdentityResult?> PutRefresh(string username, string token);
    }
}