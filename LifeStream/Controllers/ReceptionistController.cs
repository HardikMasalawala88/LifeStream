using LifeStream.Areas.Identity.Data;
using LifeStream.Data;
using LifeStream.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LifeStream.Controllers
{
    public class ReceptionistController : Controller
    {
        private readonly UserManager<LifeStreamUser> _userManager;
        private readonly LifeStreamdDBContext dBContext;

        public ReceptionistController(LifeStreamdDBContext dBContext, UserManager<LifeStreamUser> userManager)
        {
            this.dBContext = dBContext;
            _userManager = userManager;
        }
        // GET: ReceptionistController
        public async Task<ActionResult> Index(string searchQuery)
        {
            var receptionists = dBContext.Receptionists.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                receptionists = receptionists.Where(r =>
                    r.FirstName.Contains(searchQuery) ||
                    r.LastName.Contains(searchQuery) ||
                    r.Email.Contains(searchQuery));

            }

            return View(await receptionists.ToListAsync());
        }

        // GET: ReceptionistController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id) || dBContext.Doctors == null)
            {
                return NotFound();
            }
            var recep = await dBContext.Receptionists.FirstOrDefaultAsync(x => x.UserId == id);

            if (recep == null)
            {
                return NotFound();
            }
            return View(recep);
        }

        // GET: ReceptionistController/Create
        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(dBContext.Users, "Id", "UserName");
            return View();
        }

        // POST: ReceptionistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(Receptionist recep)
            {
                if (ModelState.IsValid)
                {
                    
                        var user = new LifeStreamUser
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserName = recep.Email,
                            NormalizedUserName = recep.Email.ToUpper(),
                            Email = recep.Email,
                            NormalizedEmail = recep.Email.ToUpper(),
                            FirstName = recep.FirstName,
                            LastName = recep.LastName,
                            Role = UserRole.Receptionist, // Assign Patient Role
                            //PhoneNumber = doc.PhoneNumber,
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        };

                        var result = await _userManager.CreateAsync(user, "Test@123"); // You may use a random password generator

                        if (result.Succeeded)
                        {
                            // Step 2: Assign "Patient" role to the new user
                            await _userManager.AddToRoleAsync(user, UserRole.Patient.ToString());

                            // Step 3: Save user ID in the Patient table
                            recep.UserId = user.Id; // Assign the created UserId

                            dBContext.Receptionists.Add(recep);
                            await dBContext.SaveChangesAsync();

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
                
                    //ViewBag.UserId = new SelectList(dBContext.Users, "Id", "UserName", doc.UserId);
                    return View(recep);
            }

        // GET: ReceptionistController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptionist = await dBContext.Receptionists.FindAsync(id);
            if (receptionist == null)
            {
                return NotFound();
            }

            return View(receptionist);
        }


        // POST: ReceptionistController/Edit/5
        [HttpPost]
       
        public async Task<IActionResult> Edit(string id, Receptionist recep)
        {
            if (id != recep.UserId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                dBContext.Receptionists.Update(recep);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(recep);
        }

        // GET: ReceptionistController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || dBContext.Receptionists == null)
            {
                return NotFound();
            }

            var recepdata = await dBContext.Receptionists.FirstOrDefaultAsync(x => x.UserId == id);
            if (recepdata == null)
            {
                return NotFound();
            }
            return View(recepdata);
        }

        // POST: ReceptionistController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (id == null)
            {
                return Content("Receptionist Not Found");
            }

            var recepdata = await dBContext.Receptionists.FindAsync(id);
            if (recepdata == null)
            {
                return NotFound();
            }

            dBContext.Receptionists.Remove(recepdata);
            await dBContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
