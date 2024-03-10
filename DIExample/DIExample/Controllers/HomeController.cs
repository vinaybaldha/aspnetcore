using Autofac;
using Autofac.Core.Lifetime;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILifetimeScope _lifetimeScope;

       public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, ILifetimeScope serviceScopeFactory)
        {
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _lifetimeScope = serviceScopeFactory;
           
        }

        [Route("/")]
        public IActionResult Index()
        {
            
            List<string> cities = _citiesService1.GetCities();
            ViewBag.id1 = _citiesService1.Id;
            ViewBag.id2 = _citiesService2.Id;
            ViewBag.id3 = _citiesService3.Id;
            using (ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope())
            {
               ICitiesService? citiesService4= scope.Resolve<ICitiesService>();
                ViewBag.id4 = citiesService4?.Id;
            }
            return View(cities);
        }
    }
}
