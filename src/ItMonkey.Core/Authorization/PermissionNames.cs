namespace ItMonkey.Authorization
{
    public static class PermissionNames
    {
        //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

        public const string Pages = "Pages";

        /// <summary>
        /// 权限
        /// </summary>
        public const string Pages_Administration = "Pages.Administration";

        public const string Pages_Administration_Roles = "Pages.Administration.Roles";
        public const string Pages_Administration_Roles_Create = "Pages.Administration.Roles.Create";
        public const string Pages_Administration_Roles_Edit = "Pages.Administration.Roles.Edit";
        public const string Pages_Administration_Roles_Delete = "Pages.Administration.Roles.Delete";

        public const string Pages_Administration_Users = "Pages.Administration.Users";
        public const string Pages_Administration_Users_Create = "Pages.Administration.Users.Create";
        public const string Pages_Administration_Users_Edit = "Pages.Administration.Users.Edit";
        public const string Pages_Administration_Users_Delete = "Pages.Administration.Users.Delete";
        public const string Pages_Administration_Users_ChangePermissions = "Pages.Administration.Users.ChangePermissions";

        /// <summary>
        /// 日志
        /// </summary>
        public const string Pages_AuditLogs = "Pages.AuditLogs";
        public const string Pages_AuditLogs_Logs = "Pages.AuditLogs.Logs";

        public const string Pages_AuditLogs_Warns = "Pages.AuditLogs.Warns";

        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// Product管理权限_自带查询授权
        /// </summary>
        public const string Pages_Shop = "Pages.Shop";
        public const string Pages_Shop_Product = "Pages.Shop.Product";

        /// <summary>
        /// Product创建权限
        /// </summary>
        public const string Pages_Shop_Product_CreateProduct = "Pages.Shop.Product.CreateProduct";
        /// <summary>
        /// Product修改权限
        /// </summary>
        public const string Pages_Shop_Product_EditProduct = "Pages.Shop.Product.EditProduct";
        /// <summary>
        /// Product删除权限
        /// </summary>
        public const string Pages_Shop_Product_DeleteProduct = "Pages.Shop.Product.DeleteProduct";

        /// <summary>
        /// Product批量删除权限
        /// </summary>
        public const string Pages_Shop_Product_BatchDeleteProducts = "Pages.Shop.Product.BatchDeleteProducts";

    }
}
