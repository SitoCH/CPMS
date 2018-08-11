using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", "index.html"), "text/html");
        }
    }
}
