using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces.GenericInterface;

namespace BlazorPunchCard.Repositories.Interfaces
{
    public interface IPunchRepository : IGenericRepository<Punch>
    {
        Task<List<Punch>> GetByCompanyId(int id);
        Task<int> GetTotalNumberOfPunches(int id);
    }
}
