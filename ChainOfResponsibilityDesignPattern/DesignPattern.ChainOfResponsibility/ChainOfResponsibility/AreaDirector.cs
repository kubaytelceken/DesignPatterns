using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            ChainContext chainContext = new ChainContext();
            if (request.Amount <= 400000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.Description = "Withdrawal confirmed.The amount requested by the customer was paid.";
                customerProcess.EmployeeName = "Area Director 1";
                chainContext.CustomerProcesses.Add(customerProcess);
                chainContext.SaveChanges();
            }
            else 
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.EmployeeName = "Area Director 1";
                customerProcess.Description = "The transaction failed because the withdrawal amount exceeded the limit that the area director could pay daily.";
                chainContext.CustomerProcesses.Add(customerProcess);
                chainContext.SaveChanges();
            }
        }
    }
}
