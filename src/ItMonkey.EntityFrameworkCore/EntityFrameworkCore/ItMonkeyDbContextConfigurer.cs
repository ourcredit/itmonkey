using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ItMonkey.EntityFrameworkCore
{
    public static class ItMonkeyDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ItMonkeyDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ItMonkeyDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
