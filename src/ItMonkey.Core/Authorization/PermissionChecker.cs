using Abp.Authorization;
using ItMonkey.Authorization.Roles;
using ItMonkey.Authorization.Users;

namespace ItMonkey.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
