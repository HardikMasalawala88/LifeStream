using System.Diagnostics;
using LifeStream.Areas.Identity.Data;
using LifeStream.Data;
using LifeStream.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace LifeStream.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<LifeStreamUser> _userManager;
        private readonly LifeStreamdDBContext _dBContext;

        public HomeController(ILogger<HomeController> logger, UserManager<LifeStreamUser> userManager, LifeStreamdDBContext dBContext)
        {
            _logger = logger;
            _userManager = userManager;
            _dBContext = dBContext; // Correcting the variable name
        }


        public IActionResult Index()
        {
            //ViewData["UserID"]=_userManager.GetUserId(this.User);
            var doctors = _dBContext.Doctors.ToList();

            if (doctors == null || !doctors.Any()) // Check if no data
            {
                ViewBag.Message = "No doctors available.";
                return View(new List<Doctor>()); // Empty list mukva maate
            }

            return View(doctors);
        }

        public IActionResult login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }


    }
}
