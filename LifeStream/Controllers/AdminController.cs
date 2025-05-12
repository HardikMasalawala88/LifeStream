using LifeStream.Areas.Identity.Data;
using LifeStream.Data;
using LifeStream.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace LifeStream.Controllers
{
    [Authorize(Roles = "Admin,Receptionist")]
    public class AdminController : Controller
    {
        private readonly UserManager<LifeStreamUser> _userManager;
        private readonly LifeStreamdDBContext _context;
        private readonly IHubContext<NotificationHub> _hubContext;

        public AdminController(
            UserManager<LifeStreamUser> userManager,
            LifeStreamdDBContext context,
            IHubContext<NotificationHub> hubContext)
        {
            _userManager = userManager;
            _context = context;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            var today = DateTime.Today;
            var currentYear = DateTime.Now.Year;

            ViewBag.TotalPatients = _context.Patients.Count();
            ViewBag.TotalDoctors = _context.Doctors.Count();
            ViewBag.TotalAppointments = _context.Appointments.Count();
            ViewBag.TotalFeedbacks = _context.Feedbacks.Count();
            ViewBag.MaleCount = _context.Patients.Count(p => p.Gender == "Male");
            ViewBag.FemaleCount = _context.Patients.Count(p => p.Gender == "Female");

            var monthlyAppointments = Enumerable.Range(1, 12)
                .Select(month => new
                {
                    Month = new DateTime(currentYear, month, 1).ToString("MMM"),
                    Count = _context.Appointments.Count(a => a.AppointmentDate.Year == currentYear && a.AppointmentDate.Month == month)
                })
                .ToList();

            ViewBag.AppointmentMonths = string.Join(",", monthlyAppointments.Select(m => $"'{m.Month}'"));
            ViewBag.MonthlyCounts = string.Join(",", monthlyAppointments.Select(m => m.Count));

            var upcomingAppointments = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.AppointmentDate >= DateTime.Now)
                .OrderBy(a => a.AppointmentDate)
                .Take(5)
                .ToList();

            return View(upcomingAppointments);
        }

    }
}