using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifeStream.Data;
using LifeStream.Models;
using LifeStream.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using LifeStream.Areas.Identity.Data;

namespace LifeStream.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly LifeStreamdDBContext _context;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly UserManager<LifeStreamUser> _userManager;

        public AppointmentsController(
            LifeStreamdDBContext context,
            IHubContext<NotificationHub> hubContext,
            UserManager<LifeStreamUser> userManager)
        {
            _context = context;
            _hubContext = hubContext;
            _userManager = userManager;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var appointments = _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient);
            return View(await appointments.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);

            if (appointment == null) return NotFound();

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["DoctorList"] = new SelectList(_context.Doctors, "UserId", "Name");
            ViewData["PatientList"] = new SelectList(_context.Patients, "UserId", "PatientName");
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (appointment.AppointmentDate <= DateTime.Now)
                ModelState.AddModelError("AppointmentDate", "Appointment date must be in the future.");

            if (_context.Appointments.Any(a =>
                a.DoctorId == appointment.DoctorId &&
                a.PatientId == appointment.PatientId &&
                a.AppointmentDate == appointment.AppointmentDate))
            {
                ModelState.AddModelError("", "Duplicate appointment for selected doctor and patient.");
            }

            if (_context.Appointments.Any(a =>
                a.PatientId == appointment.PatientId &&
                a.AppointmentDate == appointment.AppointmentDate &&
                a.DoctorId != appointment.DoctorId))
            {
                ModelState.AddModelError("AppointmentDate", "Patient already has another appointment at the same time.");
            }

            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                _context.Entry(appointment).Reference(a => a.Patient).Load();
                _context.Entry(appointment).Reference(a => a.Doctor).Load();

                await _hubContext.Clients.All.SendAsync("ReceiveNotification",
                    $"New appointment booked for <strong>{appointment.Patient?.PatientName}</strong> with Dr. <strong>{appointment.Doctor?.Name}</strong> on <strong>{appointment.AppointmentDate:f}</strong>.");

                return RedirectToAction(nameof(Index));
            }

            ViewData["DoctorList"] = new SelectList(_context.Doctors, "UserId", "Name", appointment.DoctorId);
            ViewData["PatientList"] = new SelectList(_context.Patients, "UserId", "PatientName", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            ViewData["DoctorList"] = new SelectList(_context.Doctors, "UserId", "Name", appointment.DoctorId);
            ViewData["PatientList"] = new SelectList(_context.Patients, "UserId", "PatientName", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId) return NotFound();

            if (appointment.AppointmentDate <= DateTime.Now)
                ModelState.AddModelError("AppointmentDate", "Appointment date must be in the future.");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["DoctorList"] = new SelectList(_context.Doctors, "UserId", "Name", appointment.DoctorId);
            ViewData["PatientList"] = new SelectList(_context.Patients, "UserId", "PatientName", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null) return NotFound();

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
