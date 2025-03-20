using LifeStream.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeStream.Models
{
    public class Receptionist
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public LifeStreamUser? User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
