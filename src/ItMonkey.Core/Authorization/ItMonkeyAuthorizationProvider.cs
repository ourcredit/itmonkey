using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ItMonkey.Authorization
{
    public class ItMonkeyAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("页面"));

            var administration = pages.CreateChildPermission(PermissionNames.Pages_Administration, L("权限管理"));

            var roles = administration.CreateChildPermission(PermissionNames.Pages_Administration_Roles, L("角色"));
            roles.CreateChildPermission(PermissionNames.Pages_Administration_Roles_Create, L("创建角色"));
            roles.CreateChildPermission(PermissionNames.Pages_Administration_Roles_Edit, L("编辑角色"));
            roles.CreateChildPermission(PermissionNames.Pages_Administration_Roles_Delete, L("删除角色"));

            var users = administration.CreateChildPermission(PermissionNames.Pages_Administration_Users, L("用户"));
            users.CreateChildPermission(PermissionNames.Pages_Administration_Users_Create, L("创建用户"));
            users.CreateChildPermission(PermissionNames.Pages_Administration_Users_Edit, L("编辑用户"));
            users.CreateChildPermission(PermissionNames.Pages_Administration_Users_Delete, L("删除用户"));
            users.CreateChildPermission(PermissionNames.Pages_Administration_Users_ChangePermissions, L("修改权限"));


            var auditlogs = pages.CreateChildPermission(PermissionNames.Pages_AuditLogs, L("审计日志"));
            auditlogs.CreateChildPermission(PermissionNames.Pages_AuditLogs_Logs, L("日志信息"));
            auditlogs.CreateChildPermission(PermissionNames.Pages_AuditLogs_Warns, L("报警信息"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ItMonkeyConsts.LocalizationSourceName);
        }
    }
}
