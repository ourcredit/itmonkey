using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.Jobs.Dtos
{
    public class CreateOrUpdateJobInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public JobEditDto Job { get; set; }

}
}