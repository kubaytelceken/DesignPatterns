using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.EntityLayer.Concrete
{
    public class Process
    {
        public int ProcessId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }   
        public decimal Amount { get; set; }   
    }
}
