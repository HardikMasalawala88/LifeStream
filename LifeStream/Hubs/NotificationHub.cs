using LifeStream.Models;
using Microsoft.AspNetCore.SignalR;

namespace LifeStream.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task AppointmentCreation(Appointment appointment)
        {
            string patientName = appointment.Patient?.PatientName ?? "Unknown";
            string doctorName = appointment.Doctor?.Name ?? "Unknown";
            string appointmentTime = appointment.AppointmentDate.ToString("f"); // full date/time string

            string message = $"New appointment booked for <strong>{patientName}</strong> with Dr. <strong>{doctorName}</strong> on <strong>{appointmentTime}</strong>.";
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
