using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ItMonkey.Configuration;
using ItMonkey.Web;

namespace ItMonkey.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ItMonkeyDbContextFactory : IDesignTimeDbContextFactory<ItMonkeyDbContext>
    {
        public ItMonkeyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ItMonkeyDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ItMonkeyDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ItMonkeyConsts.ConnectionStringName));

            return new ItMonkeyDbContext(builder.Options);
        }
    }
}
