using BlazorPunchCard.Data;
using BlazorPunchCard.Repositories.Interfaces.GenericInterface;

namespace BlazorPunchCard.Repositories.Interfaces
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser, string>
    {
        Task<ApplicationUser> GetByPhoneNumber(string phoneNumber);
    }
}
