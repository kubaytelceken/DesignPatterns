using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            ChainContext chainContext = new ChainContext();
            if (request.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.Description = "Withdrawal confirmed.The amount requested by the customer was paid.";
                customerProcess.EmployeeName = "Manager Asistant 1";
                chainContext.CustomerProcesses.Add(customerProcess);
                chainContext.SaveChanges();
            }
            else if (nextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.EmployeeName = "Manager Asistant 1";
                customerProcess.Description = "The transaction was directed to the branch manager because the withdrawal amount exceeded the limit that the assistant branch manager could pay daily.";
                chainContext.CustomerProcesses.Add(customerProcess);
                chainContext.SaveChanges();
                nextApprover.ProcessRequest(request);

            }
        }
    }
}
