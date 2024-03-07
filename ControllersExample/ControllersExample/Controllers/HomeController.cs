using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("<h1>Welcome</h1> <h2>hello from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult about()
        {
            Person person = new Person();
            person.Id= Guid.NewGuid();
            person.Name = "vinay";
            person.Age = 20;
            return Json(person);
        }

        [Route("contect-us/{mobile:regex(^\\d{{10}}$)}")]
        public string contact()
        {
            return "hello from contects";
        }

        [Route("download")]
        public VirtualFileResult file()
        {
            return File("/img.jpeg", "image/jpeg");
        }

        [Route("download2")]
        public PhysicalFileResult file2()
        {
            return PhysicalFile(@"E:\programming\aspnetcore\ControllersExample\sample.pdf", "application/pdf");
        }

        [Route("download3")]
        public FileContentResult file3()
        {
            byte[] file = System.IO.File.ReadAllBytes(@"E:\programming\aspnetcore\ControllersExample\sample.pdf");

            return File(file, "application/pdf");
        }

    }
}
