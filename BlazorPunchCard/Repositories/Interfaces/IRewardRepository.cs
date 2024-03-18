using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces.GenericInterface;

namespace BlazorPunchCard.Repositories.Interfaces
{
    public interface IRewardRepository : IGenericRepository<Reward>
    {
        Task<List<Reward>> GetByCompanyId(int id);
        Task<Reward?> GetRewardAsync(int RedemptionCode);
        Task<bool> CodeExists(int uniqueCode);
        Task<bool> IsCodeActive(int uniqueCode);
    }
}
