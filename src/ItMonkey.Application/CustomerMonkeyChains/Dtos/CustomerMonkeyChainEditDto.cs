using System;

namespace ItMonkey.CustomerMonkeyChains.Dtos
{
    public class CustomerMonkeyChainEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public Guid? Id { get; set; }
        public long CustomerId { get; set; }
        public string JobData { get; set; }
    }
}