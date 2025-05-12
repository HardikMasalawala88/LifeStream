using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifeStream.Data;
using LifeStream.Models;
using LifeStream.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using LifeStream.Hubs; 


namespace LifeStream.Controllers
{
    public class PatientsController : Controller
    {
        private readonly LifeStreamdDBContext _context;
        private readonly UserManager<LifeStreamUser> _userManager;
        private readonly IHubContext<NotificationHub> _hubContext;

        public PatientsController(LifeStreamdDBContext context, UserManager<LifeStreamUser> userManager, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        // GET: Patients
        public async Task<IActionResult> Index(string searchQuery)
        {
            var patients = _context.Patients.Include(p => p.User).AsQueryable();
                _context.Patients.Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor).ToList(); 

            if (!string.IsNullOrEmpty(searchQuery))
            {
                patients = patients.Where(p =>
                    p.FirstName.Contains(searchQuery) ||
                    p.LastName.Contains(searchQuery) ||
                    p.Email.Contains(searchQuery) ||
                    p.PhoneNumber.Contains(searchQuery) ||
                    p.PatientName.Contains(searchQuery));
            }

            return View(await patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .Include(p => p.User).Include(p=> p.Appointments)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var user = new LifeStreamUser
                {
                    UserName = patient.Email,
                    Email = patient.Email,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Role = UserRole.Patient, // Assign Patient Role
                    PhoneNumber = patient.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, "Test@123"); // You may use a random password generator

                if (result.Succeeded)
                {
                    
                    await _userManager.AddToRoleAsync(user, UserRole.Patient.ToString());

                    patient.UserId = user.Id; 

                    patient.Age = CalculateAge(patient.DateOfBirth);
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();

                    await _hubContext.Clients.All.SendAsync("ReceiveActivity", new
                    {
                        icon = "fas fa-user-plus",
                        message = $"New Patient Registered: {patient.PatientName}",
                        time = DateTime.Now.ToString("g")
                    });

                    return RedirectToAction(nameof(Index));
                }
                else
                { 
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(patient);
        }

        
        public int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;

            if (dob > today)
            {
                throw new ArgumentException("Date of Birth cannot be in the future.");
            }

            int age = today.Year - dob.Year;

            // If the birthday has not occurred this year, subtract 1
            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }



        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", patient.UserId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Patient patient)
        {
            if (id != patient.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    patient.Age = CalculateAge(patient.DateOfBirth);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", patient.UserId);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(string id)
        {
            return _context.Patients.Any(e => e.UserId == id);
        }
    }
}
