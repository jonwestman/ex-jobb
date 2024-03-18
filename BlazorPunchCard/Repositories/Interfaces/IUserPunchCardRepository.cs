using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces.GenericInterface;

namespace BlazorPunchCard.Repositories.Interfaces
{
    public interface IUserPunchCardRepository : IGenericRepository<UserPunchCard>
    {
        Task<List<UserPunchCard>> GetByIds(int punchCardId, string userId);
    }
}
