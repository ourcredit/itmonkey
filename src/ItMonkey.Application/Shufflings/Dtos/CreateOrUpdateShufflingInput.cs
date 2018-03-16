using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.Shufflings.Dtos
{
    public class CreateOrUpdateShufflingInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public ShufflingEditDto Shuffling { get; set; }

}
}