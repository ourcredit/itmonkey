using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.Shufflings.Dtos
{
    public class ShufflingEditDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Sort { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
    }
}