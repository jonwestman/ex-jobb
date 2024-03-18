using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorPunchCard.Repositories
{
    public class UserPunchCardRepository : IUserPunchCardRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public UserPunchCardRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(UserPunchCard entity)
        {
            await _dbContext.UserPunchCards.AddAsync(entity);
            await SaveAsync();
        }

        public Task DeleteByIdAsync(int id) => throw new NotImplementedException();

        public Task<List<UserPunchCard>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserPunchCard>> GetByIds(int punchCardId, string userId)
        {
            var userPunchCard = await _dbContext.UserPunchCards
                .Include(up => up.Punches)
                .Where(up => up.FK_PunchCardId == punchCardId && up.FK_ApplicationUserId == userId)
                .ToListAsync();

            return userPunchCard;
        }

        public async Task<UserPunchCard> GetById(int punchCardId)
        {
              throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UserPunchCard entity)
        {
            _dbContext.UserPunchCards.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
