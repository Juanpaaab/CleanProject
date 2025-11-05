using CleanCodeApp.Domain.Interfaces;
using CleanCodeApp.Infrastructure.Data;
using CleanCodeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users
            .AsNoTracking()
            .ToListAsync();

        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
