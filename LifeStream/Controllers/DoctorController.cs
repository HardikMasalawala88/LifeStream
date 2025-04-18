﻿using LifeStream.Areas.Identity.Data;
using LifeStream.Data;
using LifeStream.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LifeStream.Controllers
{
    public class DoctorController : Controller
    {
        private readonly UserManager<LifeStreamUser> _userManager;
        private readonly LifeStreamdDBContext dBContext;

        public DoctorController(LifeStreamdDBContext dBContext, UserManager<LifeStreamUser> userManager)
        {
            this.dBContext = dBContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchQuery)
        {
            var doctors = dBContext.Doctors.Include(d => d.User).AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                doctors = doctors.Where(d => d.FirstName.Contains(searchQuery) ||
                                             d.LastName.Contains(searchQuery) ||
                                             d.Email.Contains(searchQuery) ||
                                             d.Specialization.Contains(searchQuery));
            }

            return View(await doctors.ToListAsync());
        }


        // ✅ GET: Doctor/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await dBContext.Doctors
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // ✅ GET: Doctor/Create
        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(dBContext.Users, "Id", "UserName");
            ViewBag.SpecializationList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Cardiologist", Value = "Cardiologist" },
                new SelectListItem { Text = "Dermatologist", Value = "Dermatologist" },
                new SelectListItem { Text = "Neurologist", Value = "Neurologist" },
                new SelectListItem { Text = "Pediatrician", Value = "Pediatrician" },
                new SelectListItem { Text = "Orthopedic Surgeon", Value = "Orthopedic Surgeon" },
                new SelectListItem { Text = "Psychiatrist", Value = "Psychiatrist" },
                new SelectListItem { Text = "General Surgeon", Value = "General Surgeon" }
            };
            return View();
        }

        // ✅ POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                // ✅ Step 1: Create User
                var user = new LifeStreamUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.Email,
                    NormalizedUserName = model.Email.ToUpper(),
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = UserRole.Doctor,
                    PhoneNumber = model.PhoneNumber,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(user, "Test@123");

                if (result.Succeeded)
                {
                    // ✅ Step 2: Handle Image Upload
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/doctors");

                        // ✅ Create Directory If Not Exists
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        // ✅ Generate Unique File Name
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                        var filePath = Path.Combine(folderPath, fileName);

                        // ✅ Save the Image in Folder
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        // ✅ Save Image Path in Database
                        model.ImagePath = "/image/doctors/" + fileName;
                    }
                    else
                    {
                        // ✅ Set Default Image If No Image Uploaded
                        model.ImagePath = "/image/BCA.png";
                    }

                    // ✅ Step 3: Save Doctor Data
                    model.UserId = user.Id;
                    dBContext.Doctors.Add(model);
                    await dBContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // ✅ Handle Errors If User Creation Fails
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        // ✅ GET: Edit Doctor
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await dBContext.Doctors.FirstOrDefaultAsync(d => d.UserId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            ViewBag.SpecializationList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Cardiologist", Value = "Cardiologist" },
                new SelectListItem { Text = "Dermatologist", Value = "Dermatologist" },
                new SelectListItem { Text = "Neurologist", Value = "Neurologist" },
                new SelectListItem { Text = "Pediatrician", Value = "Pediatrician" },
                new SelectListItem { Text = "Orthopedic Surgeon", Value = "Orthopedic Surgeon" },
                new SelectListItem { Text = "Psychiatrist", Value = "Psychiatrist" },
                new SelectListItem { Text = "General Surgeon", Value = "General Surgeon" }
            };

            return View(doctor);
          }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Doctor doctor, IFormFile? ImageFile)
        {
            if (id != doctor.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingDoctor = await dBContext.Doctors.FindAsync(id);

                if (existingDoctor == null)
                {
                    return NotFound();
                }

                // ✅ Image Handling
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    if (!string.IsNullOrEmpty(existingDoctor.ImagePath))
                    {
                        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingDoctor.ImagePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/doctors");
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    existingDoctor.ImagePath = "/image/doctors/" + fileName;
                }

                // ✅ Update doctor properties
                existingDoctor.FirstName = doctor.FirstName;
                existingDoctor.LastName = doctor.LastName;
                existingDoctor.Email = doctor.Email;
                existingDoctor.Specialization = doctor.Specialization;
                existingDoctor.Gender = doctor.Gender;
                existingDoctor.Age = doctor.Age;
                existingDoctor.PhoneNumber = doctor.PhoneNumber;
                existingDoctor.ExprienceYear = doctor.ExprienceYear;

                dBContext.Doctors.Update(existingDoctor);
                await dBContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // ❗ Model invalid — repopulate dropdown
            ViewBag.SpecializationList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Cardiologist", Value = "Cardiologist" },
                    new SelectListItem { Text = "Dermatologist", Value = "Dermatologist" },
                    new SelectListItem { Text = "Neurologist", Value = "Neurologist" },
                    new SelectListItem { Text = "Pediatrician", Value = "Pediatrician" },
                    new SelectListItem { Text = "Orthopedic Surgeon", Value = "Orthopedic Surgeon" },
                    new SelectListItem { Text = "Psychiatrist", Value = "Psychiatrist" },
                    new SelectListItem { Text = "General Surgeon", Value = "General Surgeon" }
                };

            // ✅ Retain current image path on validation error
            var originalDoctor = await dBContext.Doctors.FindAsync(id);
            if (originalDoctor != null)
            {
                doctor.ImagePath = originalDoctor.ImagePath;
            }

            return View(doctor);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await dBContext.Doctors.FirstOrDefaultAsync(d => d.UserId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }


        // ✅ DELETE: Delete Doctor
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var doctor = await dBContext.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            // ✅ Delete Image from Folder
            if (!string.IsNullOrEmpty(doctor.ImagePath))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", doctor.ImagePath.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            // ✅ Delete Doctor from Database
            dBContext.Doctors.Remove(doctor);
            await dBContext.SaveChangesAsync();

            // ✅ Delete User
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
