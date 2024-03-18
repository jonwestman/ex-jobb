using BlazorPunchCard.Repositories.Interfaces.GenericInterface;
using Shared.Models;

namespace BlazorPunchCard.Repositories.Interfaces
{
    public interface IPunchCardRepository : IGenericRepository<PunchCard>
    {
        Task<List<PunchCard>> GetPunchCardsByCompanyIdAsync(int id);
    }
}
