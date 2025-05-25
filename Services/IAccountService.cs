using CockroachDBApi.Models;

namespace CockroachDBApi.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(Guid id); // <- Make this nullable
        Task<Account> CreateAsync(Account account);
        Task<bool> DeleteAsync(Guid id);
    }
}
