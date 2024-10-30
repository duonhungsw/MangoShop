using Core.Interfaces;
using Mango.Service.AccountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.AccountAPI.Repository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Role GetRoleByNameAsync(string roleName);
    }
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AccountDbContext context) : base(context)
        {
        }
        public Role GetRoleByNameAsync(string roleName)
        {
            try
            {
                return  _context.Roles
                    .FirstOrDefault(x => x.RoleName.Equals(roleName));
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("Task was canceled: " + ex.Message);
                return null;
            }
        }

    }
}
