using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TESH3Project.Models;


namespace TESH3Project.Controllers
{
    [Authorize, RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<TESH3Project.Models.ApplicationUser>(new UserStore<TESH3Project.Models.ApplicationUser>(new TESH3Project.Models.ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserId);
                var nombre = currentUser.FirstName;
                var apellido = currentUser.LastName;
                ViewBag.FirstName = nombre;
                ViewBag.LastName = apellido;
            }
            return View();
        }

        public ActionResult About()
        {
            if (Request.IsAuthenticated)
            {
                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<TESH3Project.Models.ApplicationUser>(new UserStore<TESH3Project.Models.ApplicationUser>(new TESH3Project.Models.ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserId);
                var nombre = currentUser.FirstName;
                var apellido = currentUser.LastName;
                ViewBag.FirstName = nombre;
                ViewBag.LastName = apellido;
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Request.IsAuthenticated)
            {
                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<TESH3Project.Models.ApplicationUser>(new UserStore<TESH3Project.Models.ApplicationUser>(new TESH3Project.Models.ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserId);
                var nombre = currentUser.FirstName;
                var apellido = currentUser.LastName;
                ViewBag.FirstName = nombre;
                ViewBag.LastName = apellido;
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}