using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LifeStream.Areas.Identity.Data;

namespace LifeStream.Models
{
    public class Doctor
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public LifeStreamUser? User { get; set; }

        [Required]
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required]
        public string Specialization { get; set; }
        public string Gender { get; set; }

        [Required]
        [Range(26, 60, ErrorMessage = "Age must be between 26 and 60.")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(1, 35, ErrorMessage = "Age must be between 1 and 35.")]
        public int ExprienceYear { get; set; }
        public string? ImagePath { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }
}
