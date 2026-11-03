using HurtowniaAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Services.Interfaces
{
    public interface IRodzajPrzesyłkiService
    {
        IQueryable<RodzajPrzesyłkiDto> GetRodzajePrzesyłki();
        ValueTask<RodzajPrzesyłkiDto?> GetRodzajPrzesyłki(int id);
    }
}
