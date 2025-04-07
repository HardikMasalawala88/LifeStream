using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LifeStream.Models
{
    public class Bill
    {
        
            [Key]
            public int BillId { get; set; }

            [ForeignKey("Appointment")]
            public int AppointmentId { get; set; }
            public Appointment? Appointment { get; set; }
            public decimal Amount { get; set; }

            public string PaymentStatus { get; set; }

            public DateTime PaymentDate { get; set; }
        
    }
}
