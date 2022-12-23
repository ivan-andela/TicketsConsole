using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsConsole
{
    public class SameCityVerifier : ICustomerEventVerifier
    {
        public bool Verify(Customer customer, Event e)
        {
            return customer.City == e.City;
        }
    }
}
