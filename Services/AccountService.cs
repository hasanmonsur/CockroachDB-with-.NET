using CockroachDBApi.Data;
using CockroachDBApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CockroachDBApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly BankContext _context;

        public AccountService(BankContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> CreateAsync(Account account)
        {
            account.Id = Guid.NewGuid();
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return false;

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
