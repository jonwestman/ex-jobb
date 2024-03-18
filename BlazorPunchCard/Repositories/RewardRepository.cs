using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Data.Models.ViewModels;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorPunchCard.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RewardRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Reward entity)
        {
            await _dbContext.AddAsync(entity);
            await SaveAsync();
        }

        public Task<bool> CodeExists(int uniqueCode)
        {
            var code = _dbContext.Rewards.Any(c => c.RedemptionCode == uniqueCode);

            return Task.FromResult(code);
        }

        public Task DeleteByIdAsync(int id) => throw new NotImplementedException();

        public Task<List<Reward>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Reward>> GetByCompanyId(int id)
        {
            var rewards = await (from r in _dbContext.Rewards.AsNoTracking()
                                 join up in _dbContext.UserPunchCards on r.FK_UserPunchCardId equals up.UserPunchCardId
                                 join pc in _dbContext.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                 join c in _dbContext.Companies on pc.FK_CompanyId equals c.CompanyId
                                 where c.CompanyId == id
                                 select r)
                                 .ToListAsync();

            return rewards;
        }

        public Task<Reward?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Reward?> GetRewardAsync(int RedemptionCode)
        {
            var reward = await _dbContext.Rewards.FirstOrDefaultAsync(r => r.RedemptionCode == RedemptionCode);
            return reward;
        }

        public Task<bool> IsCodeActive(int uniqueCode)
        {
            var code = _dbContext.Rewards.Any(c => c.RedemptionCode == uniqueCode && c.IsActive == true);

            return Task.FromResult(code);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Reward entity)
        {
            _dbContext.Update(entity);
            await SaveAsync();
        }
    }
}
