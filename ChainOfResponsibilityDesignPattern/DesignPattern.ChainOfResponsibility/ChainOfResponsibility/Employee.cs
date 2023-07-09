using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee nextApprover;
        public void setNextApprover(Employee supervisor)
        {
            this.nextApprover = supervisor;
        }

        public abstract void ProcessRequest(CustomerProcessViewModel request);

    }
}
