using BlazorPunchCard.Data.Models.ViewModels;
using BlazorPunchCard.Repositories.Interfaces;

namespace BlazorPunchCard.Controller
{
	public class DashBoardController
    {
        private readonly IDashBoardRepository _dashBoardRepository;

        public DashBoardController(IDashBoardRepository dashBoardRepository)
        {
            _dashBoardRepository = dashBoardRepository;
        }
        public Task<List<DashBoardViewModel>> PopulateDashboard(int companyId) 
        {
            var transaction = _dashBoardRepository.GetByCompanyId(companyId);

            return transaction;
        }
    }
}
