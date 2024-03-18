using BlazorPunchCard.Data.Models.ViewModels;

namespace BlazorPunchCard.Repositories.Interfaces
{
    public interface IDashBoardRepository
    {
        Task<List<DashBoardViewModel>> GetByCompanyId(int id);
        Task<int> GetTotalNumberOfPunchCards(int id);
        Task<int> GetNumberOfActivePunchCards(int id);
        Task<int> GetNumberOfRewardsGiven(int id);
        Task<int> GetNumberOfRewardsRedeemed(int id);
    }
}
