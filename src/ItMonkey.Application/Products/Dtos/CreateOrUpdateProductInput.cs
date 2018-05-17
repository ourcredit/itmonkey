using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.Products.Dtos
{
    public class CreateOrUpdateProductInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public ProductEditDto Product { get; set; }

}
}