using HurtowniaAPI.Dto;
using System.IdentityModel.Tokens.Jwt;

namespace HurtowniaAPI.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string?> GenerujJwToken(string login, string rola);
        JwtSecurityToken? DecodeToken(string token);
        string GenerujRefreshToken();
        bool IsCorrect(RefreshDto token);
        bool IsValid(RefreshDto token);
        Task<string?> GetToken(RefreshDto token);
    }
}