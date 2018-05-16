using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ItMonkey.Authorization.Roles;
using ItMonkey.Authorization.Users;
using ItMonkey.Models;
using ItMonkey.Models.MonkeyChain;
using ItMonkey.MultiTenancy;

namespace ItMonkey.EntityFrameworkCore
{
    public class ItMonkeyDbContext : AbpZeroDbContext<Tenant, Role, User, ItMonkeyDbContext>
    {
        /// <summary>
        /// 客户定义
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// 工作定义
        /// </summary>
        public virtual DbSet<Job> Jobs { get; set; }
        /// <summary>
        /// 客户参与的工作定义
        /// </summary>
        public virtual DbSet<CustomerJob> CustomerJobs { get; set; }
        /// <summary>
        /// 轮播图
        /// </summary>
        public virtual DbSet<Shuffling> Shufflings { get; set; }
        /// <summary>
        /// 消息记录存储
        /// </summary>
        public virtual DbSet<MessageStore> MessageStores { get; set; }
        /// <summary>
        /// 家族存储
        /// </summary>
        public virtual  DbSet<Family> Families { get; set; }
        /// <summary>
        /// 猿人币定义
        /// </summary>
        public virtual  DbSet<MonkeyChain> MonkeyChains { get; set; }
        /// <summary>
        /// 用户持有的猿人币
        /// </summary>
        public virtual  DbSet<CustomerMonkeyChain> CustomerMonkeyChains { get; set; }
        /// <summary>
        /// 用户工作经验
        /// </summary>
        public virtual  DbSet<CustomerExperience> CustomerExperiences { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public virtual  DbSet<Product> Products { get; set; }
        /// <summary>
        /// 订单信息
        /// </summary>
        public virtual  DbSet<Order> Orders { get; set; }
        /// <summary>
        /// 收货人地址列表
        /// </summary>
        public virtual  DbSet<CustomerAddress> CustomerAddresses { get; set; }
        /// <summary>
        /// 提现信息记录
        /// </summary>
        public virtual  DbSet<WithDrawa> WithDrawas { get; set; }

        public ItMonkeyDbContext(DbContextOptions<ItMonkeyDbContext> options)
            : base(options)
        {
        }
    }
}
