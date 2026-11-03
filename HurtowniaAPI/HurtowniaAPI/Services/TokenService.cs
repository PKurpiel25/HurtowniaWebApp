using HurtowniaAPI.Dto;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace HurtowniaAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Użytkownik> _userManager;

        public TokenService(IConfiguration configuration, UserManager<Użytkownik> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string?> GenerujJwToken(string login, string rola)
        {
            var użytkownik = await _userManager.FindByNameAsync(login);
            if (użytkownik != null)
            {
                var claims = await _userManager.GetClaimsAsync(użytkownik);

                var jwtKey = _configuration["Authentication:JwtKey"];
                if (jwtKey != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Authentication:JwtExpire"]));

                    var token = new JwtSecurityToken(_configuration["Authentication:JwtIssuer"], _configuration["Authentication:JwtIssuer"], claims, expires: expires, signingCredentials: cred);

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var result = tokenHandler.WriteToken(token);

                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public JwtSecurityToken? DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtKey = _configuration["Authentication:JwtKey"];
            if (jwtKey != null)
            {
                handler.ValidateToken(token, new TokenValidationParameters() 
                { 
                    ValidateIssuerSigningKey = true, 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)), 
                    ValidateIssuer = false, 
                    ValidateAudience = false, 
                    ClockSkew = TimeSpan.Zero 
                }, out SecurityToken validatedToken);
                var jwt = (JwtSecurityToken)validatedToken;
                return jwt;
            }
            else
            { 
                return null; 
            }
        }

        public string GenerujRefreshToken()
        {
            var liczby = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(liczby);
            var token = Convert.ToBase64String(liczby);
            return token;
        }

        public bool IsCorrect(RefreshDto dto)
        {
            return _userManager.Users.Any(u => u.RefreshToken == dto.Token);
        }

        public bool IsValid(RefreshDto dto)
        {
            var użytkownik = _userManager.Users.First(u => u.RefreshToken == dto.Token);
            if (użytkownik != null) 
            {
                if (użytkownik.RefreshTime > DateTime.Now) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<string?> GetToken(RefreshDto dto)
        {
            var użytkownik = _userManager.Users.First(u => u.RefreshToken == dto.Token);
            if (użytkownik != null)
            {
                var claims = await _userManager.GetClaimsAsync(użytkownik);

                var jwtKey = _configuration["Authentication:JwtKey"];
                if (jwtKey != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Authentication:JwtExpire"]));

                    var jwt = new JwtSecurityToken(_configuration["Authentication:JwtIssuer"], _configuration["Authentication:JwtIssuer"], claims, expires: expires, signingCredentials: cred);

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var result = tokenHandler.WriteToken(jwt);

                    return result;
                }
                else 
                { 
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
