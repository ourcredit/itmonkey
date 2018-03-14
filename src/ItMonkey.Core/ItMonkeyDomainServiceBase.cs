using Abp.Domain.Services;
using ItMonkey.Models;

namespace ItMonkey
{
    public abstract class ItMonkeyDomainServiceBase : DomainService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        /* Add your common members for all your domain services. */
        /*在领域服务中添加你的自定义公共方法*/
        protected ItMonkeyDomainServiceBase()
        {
            LocalizationSourceName = ItMonkeyConsts.LocalizationSourceName;
        }
    }
}
