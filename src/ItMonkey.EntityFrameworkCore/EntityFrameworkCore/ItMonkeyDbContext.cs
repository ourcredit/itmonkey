using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ItMonkey.Authorization.Roles;
using ItMonkey.Authorization.Users;
using ItMonkey.Models;
using ItMonkey.MultiTenancy;

namespace ItMonkey.EntityFrameworkCore
{
    public class ItMonkeyDbContext : AbpZeroDbContext<Tenant, Role, User, ItMonkeyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<CustomerJob> CustomerJobs { get; set; }
        public virtual DbSet<Shuffling> Shufflings { get; set; }
        public ItMonkeyDbContext(DbContextOptions<ItMonkeyDbContext> options)
            : base(options)
        {
        }
    }
}
