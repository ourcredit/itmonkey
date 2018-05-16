using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.CustomerAddresss.Dtos
{
    public class CreateOrUpdateCustomerAddressInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public CustomerAddressEditDto CustomerAddress { get; set; }

}
}