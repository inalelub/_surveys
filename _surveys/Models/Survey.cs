using System.ComponentModel.DataAnnotations;

namespace _surveys.Models
{
	public class Survey
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Your full name is  required")]
        public string FullNames { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address. An email is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Your Date of Birth is required")]
		public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Your phone number is required")]
        public string ContactNumber { get; set; }

        [Required]
        public List<string> FavouriteFood { get; set; } = new();

        [Required]
        public string ScaleMovie { get; set; }

        [Required]
        public string ScaleRadio { get; set; }

        [Required]
        public string ScaleEatOut { get; set; }

        [Required]
        public string ScaleTV { get; set; }
    }
}
