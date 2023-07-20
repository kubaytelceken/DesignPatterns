using DesignPattern.TemplateMethod.TemplatePattern;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.TemplateMethod.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult BasicPlanIndex()
        {
            NetflixPlans netflixPlans = new BasicPlan();
            ViewBag.PlanType = netflixPlans.PlanType("Basic Plan");
            ViewBag.CountPerson = netflixPlans.CountPerson(1);
            ViewBag.Price = netflixPlans.Price(65.99);
            ViewBag.Content = netflixPlans.Content("Movie,Film");
            ViewBag.Resolution = netflixPlans.Resolution("408px");
            return View();
        }
    }
}
