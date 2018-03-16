using System.ComponentModel.DataAnnotations;
using ItMonkey.Shufflings.Dtos.LTMAutoMapper;
using ItMonkey.Models;

namespace ItMonkey.Shufflings.Dtos
{
    public class ShufflingEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
    }
}