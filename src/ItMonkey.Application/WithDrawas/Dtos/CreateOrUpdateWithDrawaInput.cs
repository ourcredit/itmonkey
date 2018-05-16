using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.WithDrawas.Dtos
{
    public class CreateOrUpdateWithDrawaInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public WithDrawaEditDto WithDrawa { get; set; }

}
}