using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using ItMonkey.Models;

namespace ItMonkey.EntityFrameworkCore.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly ItMonkeyDbContext _context;

        public DefaultSettingsCreator(ItMonkeyDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            // Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com");
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer");
            CreateShufflings();
            // Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en");
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }

        private void CreateShufflings()
        {
            var list = new List<Shuffling>()
            {
                new Shuffling()
                {
                    ImageUrl = "http://img02.tooopen.com/images/20150928/tooopen_sy_143912755726.jpg",
                    IsActive = true,
                    Path = "/pages/work/index",
                    Sort = 1,
                    Title = "a"
                },
                new Shuffling()
                {
                    ImageUrl = "http://img06.tooopen.com/images/20160818/tooopen_sy_175866434296.jpg",
                    IsActive = true,
                    Path = "/pages/work/index",
                    Sort = 2,
                    Title = "b"
                },
                new Shuffling()
                {
                ImageUrl = "http://img06.tooopen.com/images/20160818/tooopen_sy_175833047715.jpg",
                IsActive = true,
                Path = "/pages/work/index",
                Sort = 3,
                Title = "c"
            }
               
            };
            foreach (var a in list)
            {
                AddShufflingsIfNotExists(a);
            }
        }
        private void AddShufflingsIfNotExists(Shuffling model)
        {
            if (_context.Shufflings.IgnoreQueryFilters().Any(s => s.Title == model.Title && s.ImageUrl == model.ImageUrl
            ))
            {
                return;
            }

            _context.Shufflings.Add(model);
            _context.SaveChanges();
        }
    }
}
