using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifeStream.Data;
using LifeStream.Models;
using LifeStream.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace LifeStream.Controllers
{
    public class PatientsController : Controller
    {
        private readonly LifeStreamdDBContext _context;
        private readonly UserManager<LifeStreamUser> _userManager;

        public PatientsController(LifeStreamdDBContext context, UserManager<LifeStreamUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            var lifeStreamdDBContext = _context.Patients.Include(p => p.User);
            return View(await lifeStreamdDBContext.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(string id)
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
        public async Task<IActionResult> Create([Bind("UserId,PatientName,FirstName,LastName,Email,DateOfBirth,Gender,Age,PhoneNumber,Address")] Patient patient)
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
                    // Step 2: Assign "Patient" role to the new user
                    await _userManager.AddToRoleAsync(user, UserRole.Patient.ToString());

                    // Step 3: Save user ID in the Patient table
                    patient.UserId = user.Id; // Assign the created UserId

                    //patient.Age = (DateTime.Today.Year - patient.DateOfBirth.Year) -
                    //  (DateTime.Today.DayOfYear < patient.DateOfBirth.DayOfYear ? 1 : 0);
                    patient.Age = CalculateAge(patient.DateOfBirth);
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle errors if user creation fails
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(patient);
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

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
        public async Task<IActionResult> Edit(string id, [Bind("UserId,PatientName,FirstName,LastName,Email,DateOfBirth,Gender,Age,PhoneNumber,Address")] Patient patient)
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
