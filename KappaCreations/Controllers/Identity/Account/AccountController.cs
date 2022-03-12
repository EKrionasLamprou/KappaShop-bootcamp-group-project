using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using KappaCreations.Identity;

namespace KappaCreations.Controllers
{
    [Authorize]
    public partial class AccountController : Controller
    {
        public AccountController()
        {
            UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            SignInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private const string XsrfKey = "XsrfId";

        public ApplicationSignInManager SignInManager { get; private set; }

        public ApplicationUserManager UserManager { get; private set; }

        private IAuthenticationManager AuthenticationManager
        {
            get => HttpContext.GetOwinContext().Authentication;
        }
    }
}