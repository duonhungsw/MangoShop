using Core.Interfaces;
using Mango.Service.AccountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.AccountAPI.Repository;

public interface IAccountRepository : IGenericRepository<User>
{
    Task<User?> GetRoleByName(string roleName);
    Task<User?> GetUserByEmail(string email);
}
public class AccountRepository : GenericRepository<User>, IAccountRepository
{
    public AccountRepository(AccountDbContext context) : base(context)
    {
    }


    public async Task<User?> GetRoleByName(string roleName) => await _context.Users
                                            .FirstOrDefaultAsync(x => x.Role.RoleName == roleName);

    public async Task<User?> GetUserByEmail(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
}
