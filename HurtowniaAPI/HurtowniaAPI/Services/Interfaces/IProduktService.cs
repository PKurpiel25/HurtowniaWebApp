using HurtowniaAPI.Dto.Produkt;
using Microsoft.AspNetCore.Mvc;

namespace HurtowniaAPI.Services.Interfaces
{
    public interface IProduktService
    {
        IQueryable<ProduktDto> GetProdukty();
        ValueTask<ProduktDetailsDto?> GetProdukt(int id);
        ValueTask<ProduktFullDto?> GetProduktFull(int id);
        Task<StatusCodeResult> PutProdukt(int id, ProduktUpdateDto dto);
        Task PostProdukt(ProduktFullDto dto);
        Task<StatusCodeResult> DeleteProdukt(int id);
        bool ProduktExists(int id);
    }
}
