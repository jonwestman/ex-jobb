using BlazorPunchCard.Data;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorPunchCard.Repositories
{ 
    public class CompanyRepository(ApplicationDbContext dbContext) : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public Task Add(Company entity) => throw new NotImplementedException();
        public Task DeleteByIdAsync(int id) => throw new NotImplementedException();
        public Task<List<Company>> GetAll() => throw new NotImplementedException();
        public Task<Company?> GetById(int id) => throw new NotImplementedException();
        public async Task<Company?> GetCompanyByUserId(string userId) => await (from c in _dbContext.Companies
                                                                                join a in _dbContext.ApplicationUsers on c.FK_ApplicationUserId equals a.Id
                                                                                where a.Id == userId
                                                                                select c).FirstOrDefaultAsync();

        public Task SaveAsync() => throw new NotImplementedException();
        public Task Update(Company entity) => throw new NotImplementedException();
    }
}
