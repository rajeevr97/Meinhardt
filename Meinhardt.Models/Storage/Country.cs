using System.ComponentModel.DataAnnotations;

namespace Meinhardt.Models.Storage
{
    public class Country
    {
        public int Id { get; set; }
       
        [Required]
        [MinLength(4, ErrorMessage ="Length should be minimum 4 letters")]
        public string? Name { get; set; }
        [StringLength(2, MinimumLength =2, ErrorMessage ="Length must be 2 letters" )]
        public string? Code1 { get; set; }
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Length must be 3 letters")]
        public string? Code2 { get; set; }

    }
}
