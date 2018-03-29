using System;

namespace ItMonkey.Authorization.Users.Dto
{
    public class GetUserForEditOutput
    {

        public UserEditDto User { get; set; }

        public UserRoleDto[] Roles { get; set; }


    }
}