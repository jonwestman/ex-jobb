using BlazorPunchCard.Data;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace BlazorPunchCard.Repositories
{
    public class ApplicationUserRepository(ApplicationDbContext context) : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task Add(ApplicationUser entity) => throw new NotImplementedException();
        public Task Delete(ApplicationUser entity) => throw new NotImplementedException();
        public async Task<ApplicationUser?> GetById(string id)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
        
        public async Task<ApplicationUser?> GetByPhoneNumber(string phoneNumber)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            return user;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            var users = await _context.ApplicationUsers.ToListAsync();
            return users;
        }

        public Task SaveAsync() => throw new NotImplementedException();
        public Task Update(ApplicationUser entity) => throw new NotImplementedException();
		public Task DeleteByIdAsync(int id) => throw new NotImplementedException();
	}
}
