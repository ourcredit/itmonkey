using System.ComponentModel.DataAnnotations;

namespace ItMonkey.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}