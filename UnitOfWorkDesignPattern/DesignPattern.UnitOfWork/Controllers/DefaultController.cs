using DesignPattern.BusinessLayer.Abstract;
using DesignPattern.EntityLayer.Concrete;
using DesignPattern.UnitOfWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPattern.UnitOfWork.Controllers
{
    public class DefaultController : Controller
    {

        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel customerViewModel)
        {
            
            List<Customer> customers = new List<Customer>(); 
            var value1 = _customerService.TGetById(customerViewModel.SenderId);
            var value2 = _customerService.TGetById(customerViewModel.ReceiverId);
            value1.CustomerBalance -= customerViewModel.Amount;
            value2.CustomerBalance += customerViewModel.Amount;
            customers.Add(value1);
            customers.Add(value2);
            _customerService.TMultiUpdate(customers);
            return View();
        }
    }
}
