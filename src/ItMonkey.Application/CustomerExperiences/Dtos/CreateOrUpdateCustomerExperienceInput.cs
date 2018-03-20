using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.CustomerExperiences.Dtos
{
    public class CreateOrUpdateCustomerExperienceInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public CustomerExperienceEditDto CustomerExperience { get; set; }

}
}