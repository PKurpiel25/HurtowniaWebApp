using HurtowniaAPI.Dto.Zdjęcie;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Services
{
    public interface IZdjęcieService
    {
        IQueryable<ZdjęcieDto> GetZdjęcia();
        IQueryable<ZdjęcieDto> GetZdjęcia(int id);
        ValueTask<ZdjęcieDto?> GetZdjęcie(int id);
        Task<StatusCodeResult> PutZdjęcie(int id, ZdjęcieFullDto dto);
        Task PostZdjęcie(ZdjęcieFullDto dto);
        Task<StatusCodeResult> DeleteZdjęcie(int id);
        bool ZdjęcieExists(int id);
    }
}
