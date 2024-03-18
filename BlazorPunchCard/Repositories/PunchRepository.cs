using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorPunchCard.Repositories
{
    public class PunchRepository : IPunchRepository
    {
        private readonly ApplicationDbContext _context;

        public PunchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Punch entity)
        {
            entity.PunchTimeRegistered = DateTime.Now;
            await _context.Punches.AddAsync(entity);
            await SaveAsync();
        }

        public Task DeleteByIdAsync(int id) => throw new NotImplementedException();

        public async Task<Punch> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Punch>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Punch entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Punch>> GetByCompanyId(int id)
        {
            var punches = await (from p in _context.Punches.AsNoTracking()
                                 join up in _context.UserPunchCards on p.FK_UserPunchCard equals up.UserPunchCardId
                                 join pc in _context.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                 join c in _context.Companies on pc.FK_CompanyId equals c.CompanyId
                                 where c.CompanyId == id
                                 select p).ToListAsync();

            return punches;
        }

        public async Task<int> GetTotalNumberOfPunches(int id)
        {
            var punches = await(from p in _context.Punches.AsNoTracking()
                                join up in _context.UserPunchCards on p.FK_UserPunchCard equals up.UserPunchCardId
                                join pc in _context.PunchCards on up.FK_PunchCardId equals pc.PunchCardId
                                join c in _context.Companies on pc.FK_CompanyId equals c.CompanyId
                                where c.CompanyId == id
                                select p).ToListAsync();

            return punches.Count();
        }
    }
}
