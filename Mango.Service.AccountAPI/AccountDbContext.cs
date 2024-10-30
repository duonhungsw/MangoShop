using Mango.Service.AccountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.AccountAPI
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users  { get; set; }
        public DbSet<Role> Roles  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
