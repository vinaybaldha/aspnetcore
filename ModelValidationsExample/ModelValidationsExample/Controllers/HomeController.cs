using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBlinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    
    public class HomeController : Controller
    {



        [Route("registration")]
        // [Bind(nameof(Person.Name), nameof(Person.Password))]
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            if (!ModelState.IsValid)
            {
                string errors = String.Join("\n",
                    ModelState.Values.SelectMany(values=>values.Errors).Select(error=>error.ErrorMessage));

                return Content(errors);
            }

            return Content($"{person} userAgent:{UserAgent}");
        }
    }
}
