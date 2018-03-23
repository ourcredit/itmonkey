using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models.MonkeyChain
{
    /// <summary>
    /// 猿人币
    /// </summary>
    [Table("m_monkey_chain")]
    public class MonkeyChain:Entity<Guid>
    {
        public MonkeyChain(long index, string data, string previousHash)
        {
            var time = TimeStamp();
           Index = index;
           TimeSpan = time;
           Data = data;
           PreviousHash = previousHash;
           JoinTemp = $"{Index}{TimeSpan}{data}{previousHash}";
           Hash = Sha256Encrypt(JoinTemp);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Sha256Encrypt(string model)
        {
            var ac=new ASCIIEncoding();
            var temp =  ac.GetBytes(model);
            var bytes = new SHA1Managed().ComputeHash(temp);
            return ac.GetString(bytes);
        }

        public static string TimeStamp()
        {
            DateTime startTime = new DateTime(1970, 1, 1);
           var ts=  (int)(DateTime.Now - startTime).TotalSeconds;
            return ts.ToString();
        }
        /// <summary>
        /// 下表
        /// </summary>
        public long Index { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeSpan { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// hash
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// 上一位hash
        /// </summary>
        public string PreviousHash { get; set; }
        private string JoinTemp { get; set; }
    }
   
}
