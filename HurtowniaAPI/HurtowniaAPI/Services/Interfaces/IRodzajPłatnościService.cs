using HurtowniaAPI.Dto;

namespace HurtowniaAPI.Services.Interfaces
{
    public interface IRodzajPłatnościService
    {
        IQueryable<RodzajPłatnościDto> GetRodzajePłatności();
        ValueTask<RodzajPłatnościDto?> GetRodzajPłatności(int id);
    }
}
