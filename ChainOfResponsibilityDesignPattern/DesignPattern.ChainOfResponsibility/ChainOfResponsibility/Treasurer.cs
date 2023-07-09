using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            ChainContext chainContext = new ChainContext();
            if(request.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.Description = "Withdrawal confirmed.The amount requested by the customer was paid.";
                customerProcess.EmployeeName = "Treasurer 1";
                chainContext.CustomerProcesses.Add(customerProcess);
                chainContext.SaveChanges();
            }
            else if(nextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.EmployeeName = "Treasurer 1";
                customerProcess.Description = "The transaction was directed to the assistant branch manager because the withdrawal amount exceeded the limit that the treasurer could pay daily.";
                chainContext.CustomerProcesses.Add(customerProcess);
                chainContext.SaveChanges();
                nextApprover.ProcessRequest(request);

            }
        }
    }
}
