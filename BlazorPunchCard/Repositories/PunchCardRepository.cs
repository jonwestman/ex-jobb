using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorPunchCard.Repositories
{
    public class PunchCardRepository(ApplicationDbContext context) : IPunchCardRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Add(PunchCard entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }
        public async Task<List<PunchCard>> GetAll()
        {
            return await _context.PunchCards.Include(pc => pc.Companies).ToListAsync();

        }
        public async Task<PunchCard?> GetById(int id)
        {
            var punchCard = await _context.PunchCards.FirstOrDefaultAsync(p => p.PunchCardId == id);
            return punchCard;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(int id)
        {
            var punchCard = await GetById(id);

            if (punchCard is not null)
            {
                _context.PunchCards.Remove(punchCard);
                await SaveAsync();
            }
        }
        public async Task Update(PunchCard entity) 
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task<List<PunchCard>> GetPunchCardsByCompanyIdAsync(int companyId)
        {
            return await _context.PunchCards.Include(pc => pc.Companies).Where(c => c.FK_CompanyId == companyId).ToListAsync();
        }
    }
}
