using System.ComponentModel.DataAnnotations;

namespace LifeStream.Models
{
    public class Nonmedicaltaff
    {
        [Key]
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string Gender {  get; set; }
        public string Jobtitle { get; set; }
        public string Department{ get; set; }
        public string Salary { get; set; }
        public string Status { get; set; } = "Active";

    }
}
