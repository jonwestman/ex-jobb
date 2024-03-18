using BlazorPunchCard.Repositories.Interfaces.GenericInterface;
using Shared.Models;

namespace BlazorPunchCard.Repositories.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company?> GetCompanyByUserId(string userId);
    }
}
