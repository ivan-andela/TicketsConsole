using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsConsole
{
    public interface ICustomerEventVerifier
    {
        bool Verify(Customer customer, Event e);
    }
}
