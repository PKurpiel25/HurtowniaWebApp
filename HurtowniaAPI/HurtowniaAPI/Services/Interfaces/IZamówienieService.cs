using HurtowniaAPI.Dto.Zamówienie;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Services
{
    public interface IZamówienieService
    {
        IQueryable<ZamówienieSingleDto> GetZamówienia();
        IQueryable<ZamówienieSingleKlientDto> GetZamówienia(string id);
        ValueTask<ZamówienieDetailsDto?> GetZamówienie(int id);
        ValueTask<ZamówienieDetailsKlientDto?> GetZamówienie_Klient(int id);
        ValueTask<ZamówienieInvoiceDto?> GetZamówienie_Faktura(int id);
        ValueTask<ZamówienieAdresDto?> GetZamówienie_Adres(int id);
        Task<StatusCodeResult> PutZamówienie(int id, ZamówienieFullDto dto);
        Task PostZamówienie(ZamówienieFullDto dto);
        Task<StatusCodeResult> DeleteZamówienie(int id);
        bool ZamówienieExists(int id);
    }
}
