using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ItMonkey.Authorization.Roles;
using ItMonkey.Authorization.Users;
using ItMonkey.MultiTenancy;

namespace ItMonkey.EntityFrameworkCore
{
    public class ItMonkeyDbContext : AbpZeroDbContext<Tenant, Role, User, ItMonkeyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ItMonkeyDbContext(DbContextOptions<ItMonkeyDbContext> options)
            : base(options)
        {
        }
    }
}
