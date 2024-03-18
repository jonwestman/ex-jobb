using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Data.Models.ViewModels;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorPunchCard.Repositories
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPunchRepository _punchRepository;

        public DashBoardRepository(ApplicationDbContext dbContext, IPunchRepository punchRepository)
        {
            _dbContext = dbContext;
            _punchRepository = punchRepository;
        }
        public async Task<List<DashBoardViewModel>> GetByCompanyId(int companyId)
        {
            int punchesToGo;

            var punches = await (from p in _dbContext.Punches.AsNoTracking()
                                 join up in _dbContext.UserPunchCards on p.FK_UserPunchCard equals up.UserPunchCardId
                                 join u in _dbContext.ApplicationUsers on up.FK_ApplicationUserId equals u.Id
                                 join pc in _dbContext.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                 join c in _dbContext.Companies on pc.FK_CompanyId equals c.CompanyId
                                 where c.CompanyId == companyId
                                 select new DashBoardViewModel
                                 {
                                     CustomerPhoneNumber = u.PhoneNumber,
                                     CustomerName = u.Name,
                                     NumberOfPunches = $"{up.Punches.Count()}/{pc.PunchCardCount}",
                                     DateAndTime = p.PunchTimeRegistered,
                                     NameOfPunchCard = pc.PunchCardName,
                                     TransactionType = "Stämpel"
                                 }).ToListAsync();

            var rewards = await (from r in _dbContext.Rewards.AsNoTracking()
                                 join up in _dbContext.UserPunchCards on r.FK_UserPunchCardId equals up.UserPunchCardId
                                 join u in _dbContext.ApplicationUsers on up.FK_ApplicationUserId equals u.Id
                                 join pc in _dbContext.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                 join c in _dbContext.Companies on pc.FK_CompanyId equals c.CompanyId
                                 where c.CompanyId == companyId
                                 select new DashBoardViewModel
                                 {
                                     CustomerPhoneNumber = u.PhoneNumber,
                                     CustomerName = u.Name,
                                     DateAndTime = r.TimeRegistered,
                                     NameOfPunchCard = pc.PunchCardName,
                                     TransactionType = "Rabatt tilldelad"
                                 }).ToListAsync();

            var transactions = punches.Concat(rewards).OrderByDescending(t => t.DateAndTime).ToList();

            return transactions;
        }

        public async Task<int> GetNumberOfActivePunchCards(int companyId)
        {
            var numberOfActiveUsers = await (from up in _dbContext.UserPunchCards.AsNoTracking()
                                             join pc in _dbContext.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                             where pc.FK_CompanyId == companyId && up.IsActive == true
                                             select up).ToListAsync();

            return numberOfActiveUsers.Count();
        }

        public async Task<int> GetTotalNumberOfPunchCards(int companyId)
        {
            var totalNumberOfActiveUsers = await (from up in _dbContext.UserPunchCards.AsNoTracking()
                                             join pc in _dbContext.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                             where pc.FK_CompanyId == companyId
                                             select up).ToListAsync();

            return totalNumberOfActiveUsers.Count();
        }

        public async Task<int> GetNumberOfRewardsGiven(int companyId)
        {
            var rewards = await (from r in _dbContext.Rewards.AsNoTracking()
                                 join up in _dbContext.UserPunchCards on r.FK_UserPunchCardId equals up.UserPunchCardId
                                 join u in _dbContext.ApplicationUsers on up.FK_ApplicationUserId equals u.Id
                                 join pc in _dbContext.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                 join c in _dbContext.Companies on pc.FK_CompanyId equals c.CompanyId
                                 where c.CompanyId == companyId
                                 select r).ToListAsync();

            return rewards.Count();
        }

        public async Task<int> GetNumberOfRewardsRedeemed(int companyId)
        {
            var rewards = await (from r in _dbContext.Rewards.AsNoTracking()
                                 join up in _dbContext.UserPunchCards on r.FK_UserPunchCardId equals up.UserPunchCardId
                                 join u in _dbContext.ApplicationUsers on up.FK_ApplicationUserId equals u.Id
                                 join pc in _dbContext.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                 join c in _dbContext.Companies on pc.FK_CompanyId equals c.CompanyId
                                 where c.CompanyId == companyId && r.IsActive == false
                                 select r).ToListAsync();

            return rewards.Count();
        }
    }
}
