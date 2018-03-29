using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using ItMonkey.Authorization.Users;
using ItMonkey.Authorization.Users.Dto;

namespace ItMonkey.Tests.Users
{
    public class UserAppService_Tests : ItMonkeyTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetUsers(new GetUsersInput(){SkipCount = 0,MaxResultCount = 20} );

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

    
    }
}
