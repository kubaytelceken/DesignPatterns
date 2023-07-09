using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel customerProcessViewModel)
        {
            Employee treasure = new Treasurer();
            Employee managerAsistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee areadirector = new AreaDirector();

            treasure.setNextApprover(managerAsistant);
            managerAsistant.setNextApprover(manager);
            manager.setNextApprover(areadirector);


            treasure.ProcessRequest(customerProcessViewModel);

            return View();
        }
    }
}
