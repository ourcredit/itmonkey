using Abp.Runtime.Validation;
using ItMonkey.Dto;
using ItMonkey.Models;

namespace ItMonkey.CustomerExperiences.Dtos
{
    public class GetCustomerExperiencesInput : PagedAndSortedInputDto, IShouldNormalize
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        /// <summary>
        /// 模糊搜索使用的关键字
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public long CustomerId { get; set; }
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
}
