using HurtowniaAPI.Dto.Zapytanie;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Services
{
    public interface IZapytanieService
    {
        IQueryable<ZapytanieSingleDto> GetZapytania();
        ValueTask<ZapytanieDetailsDto?> GetZapytanie(int id);
        Task<StatusCodeResult> PutZapytanie(int id, ZapytanieFullDto dto);
        Task PostZapytanie(ZapytanieFullDto dto);
        Task<StatusCodeResult> DeleteZapytanie(int id);
        bool ZapytanieExists(int id);
    }
}
