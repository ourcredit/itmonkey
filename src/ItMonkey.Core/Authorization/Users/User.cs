using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using Abp.Timing;

namespace ItMonkey.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }
        public DateTime? SignInTokenExpireTimeUtc { get; set; }

        public string SignInToken { get; set; }

        private new bool IsLockoutEnabled { get; set; }
        private new bool IsTwoFactorEnabled { get; set; }
        private new string EmailConfirmationCode { get; set; }
        private new bool IsEmailConfirmed { get; set; }
        private new bool IsPhoneNumberConfirmed { get; set; }
        private new string NormalizedEmailAddress { get; set; }
        private new string NormalizedUserName { get; set; }
        

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }
        public void Unlock()
        {
            AccessFailedCount = 0;
            LockoutEndDateUtc = null;
        }

        public void SetSignInToken()
        {
            SignInToken = Guid.NewGuid().ToString();
            SignInTokenExpireTimeUtc = Clock.Now.AddMinutes(1).ToUniversalTime();
        }
    }
}
