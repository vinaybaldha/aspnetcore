using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            List<Person> people = new List<Person>()
    {
        new Person
            {
                Name = "Vinay",
                BitrhDate = Convert.ToDateTime("2003-05-30"),
                PersonGender = Person.Gender.Male
            },
        new Person
            {
                Name = "Rohit",
                BitrhDate = Convert.ToDateTime("2004-04-15"),
                PersonGender = Person.Gender.Female
            },
        new Person
            {
                Name = "Ganpat",
                BitrhDate = Convert.ToDateTime("2005-03-20"),
                PersonGender = Person.Gender.Other
            },
    };
            //ViewData["people"]=people;
            //ViewBag.people=people;
            string title = "asp.net core";
            //ViewData["title"]=title;
            ViewBag.title = title;
            return View("Index", people);
        }

        [Route("persondetails/{name}")]
        public IActionResult PersonDetails(string? name)
        {
            List<Person> people = new List<Person>()
    {
        new Person
            {
                Name = "Vinay",
                BitrhDate = Convert.ToDateTime("2003-05-30"),
                PersonGender = Person.Gender.Male
            },
        new Person
            {
                Name = "Rohit",
                BitrhDate = Convert.ToDateTime("2004-04-15"),
                PersonGender = Person.Gender.Female
            },
        new Person
            {
                Name = "Ganpat",
                BitrhDate = Convert.ToDateTime("2005-03-20"),
                PersonGender = Person.Gender.Other
            },
    };
            Person? person = people.Where(temp => temp.Name == name).FirstOrDefault();
            return View(person);
        }

        [Route("/personwithproduct")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() { Name="Vinay",PersonGender=Person.Gender.Male};
            Product product = new Product() { ProductId = 1, ProductName = "leptop" };
            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel() { PersonData = person, ProductData = product };
            return View(personAndProductWrapperModel);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {

            return View();
        }
    }
}
