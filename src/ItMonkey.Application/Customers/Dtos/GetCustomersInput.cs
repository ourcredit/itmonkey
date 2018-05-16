using Abp.Runtime.Validation;
using ItMonkey.Dto;
using ItMonkey.Models;

namespace ItMonkey.Customers.Dtos
{
    public class GetCustomersInput : PagedAndSortedInputDto, IShouldNormalize
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        /// <summary>
        /// 模糊搜索使用的关键字
        /// </summary>
        public string Name { get; set; }
        public string Family { get; set; }
        public int? Level { get; set; }

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
    /// <summary>
    /// 获取消息input
    /// </summary>
    public class GetMessageInput : PagedAndSortedInputDto
    {
        /// <summary>
        /// 登陆用户id
        /// </summary>
        public long CustomerId { get; set; }
        /// <summary>
        /// 对应id
        /// </summary>
        public int SouceId { get; set; }
        /// <summary>
        /// 对应消息类型
        /// </summary>
        public MessageType Type { get; set; }
    }
}
