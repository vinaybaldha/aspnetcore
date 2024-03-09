using Microsoft.AspNetCore.Mvc;
using PartialViewExample.Models;

namespace PartialViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("programming")]
        public IActionResult prartialView()
        {
            ListModel listModel = new ListModel();
            listModel.ListTitle = "programming";
            listModel.List = new List<string>()
            {
                "aspnet core",
                "angular",
                "javascript",
                "java",
                "C#"
            };
            return PartialView("_ListPartialView",listModel);
        }
    }
}
