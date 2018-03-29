using System.Collections.Generic;
using ItMonkey.Authorization.Permissions.Dto;

namespace ItMonkey.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}