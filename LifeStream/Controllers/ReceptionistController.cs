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
        private readonly RoleManager<IdentityRole> _roleManager;

        public ReceptionistController(LifeStreamdDBContext dBContext, UserManager<LifeStreamUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.dBContext = dBContext;
            _userManager = userManager;
            _roleManager = roleManager;
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
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(user, "Rec@123");

                if (result.Succeeded)
                {
                    string roleName = UserRole.Receptionist.ToString();

                    // Ensure the role exists
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Failed to create role.");
                            return View(recep);
                        }
                    }

                    // Assign role to user
                    await _userManager.AddToRoleAsync(user, roleName);

                    // Save user ID in Receptionist table
                    recep.UserId = user.Id;

                    dBContext.Receptionists.Add(recep);
                    await dBContext.SaveChangesAsync();

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