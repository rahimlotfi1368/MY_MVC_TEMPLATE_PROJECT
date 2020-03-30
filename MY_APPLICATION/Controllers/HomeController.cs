using System.Linq;
namespace MY_APPLICATION.Controllers
{
    public partial class HomeController : Infrastracture.BaseController
    {
        public HomeController() : base()
        {

        }
        // GET: Home
        public virtual System.Web.Mvc.ViewResult Index()
        {

            return View();
        }
    }
}