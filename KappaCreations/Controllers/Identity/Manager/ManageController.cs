using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace KappaCreations.Controllers
{
    [Authorize]
    public partial class ManageController : Controller
    {
        public ManageController() 
        {
            UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            SignInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        }
        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private const string XsrfKey = "XsrfId";

        public ApplicationUserManager UserManager { get; private set; }
        public ApplicationSignInManager SignInManager { get; private set; }
        private IAuthenticationManager AuthenticationManager
        {
            get => HttpContext.GetOwinContext().Authentication;
        }
    }
}