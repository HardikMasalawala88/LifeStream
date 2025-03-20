using LifeStream.Data;
using LifeStream.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LifeStream.Controllers
{
    public class NonmedicalstaffController : Controller
    {
        private readonly LifeStreamdDBContext dBContext;
        public NonmedicalstaffController(LifeStreamdDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: NonmedicalstaffController
        public async Task<ActionResult> Index()
        {
            var nonMedical = await dBContext.nonmedicaltaffs.ToListAsync();
            return View(nonMedical);
        }

        // GET: NonmedicalstaffController/Details/5
        public async Task<ActionResult> Details(int ? id)
        {
            if (id == null) 
            { 
                return NotFound();
            }
            var nonMedical = await dBContext.nonmedicaltaffs.FirstOrDefaultAsync(x=> x.StaffId == id);
            if (nonMedical == null) 
            {
                return NotFound();
            }
                
            return View(nonMedical);
        }

        // GET: NonmedicalstaffController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NonmedicalstaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Nonmedicaltaff nonMedical)
        {
            if (ModelState.IsValid)
            {
                dBContext.nonmedicaltaffs.Add(nonMedical);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nonMedical);
        }

        // GET: NonmedicalstaffController/Edit/5
        public async Task <ActionResult> Edit(int ? id)
        {
           if(id == null)
            {
                return NotFound();
            }
           var nonMedical = await dBContext.nonmedicaltaffs.FindAsync(id);
            if (nonMedical == null)
            {
                return NotFound();
            }
            return View(nonMedical);
        }

        // POST: NonmedicalstaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Nonmedicaltaff nonMedical)
        {
            if(id != nonMedical.StaffId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                dBContext.Update(nonMedical);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nonMedical);
            
        }

        // GET: NonmedicalstaffController/Delete/5
        public ActionResult Delete(int ? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: NonmedicalstaffController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var nonMedical = await dBContext.nonmedicaltaffs.FindAsync(id);
            if(nonMedical == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                dBContext.nonmedicaltaffs.Remove(nonMedical);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nonMedical);

            
            

        }
    }
    
}
