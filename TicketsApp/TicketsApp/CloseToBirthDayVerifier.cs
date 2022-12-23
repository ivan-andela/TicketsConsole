using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsConsole
{
    public class CloseToBirthDayVerifier : ICustomerEventVerifier
    {
        public bool Verify(Customer customer, Event e)
        {
            var birthData = new DateTime(DateTime.Now.Year, customer.BirthDate.Month, customer.BirthDate.Day);

            if (DateTime.Now > birthData)
            {
                birthData = new DateTime(DateTime.Now.Year + 1, customer.BirthDate.Month, customer.BirthDate.Day);
            }

            var diff = birthData - e.Date;

            return Math.Abs(diff.TotalDays) <= 7;// we can have this in configuration, or event have a different favorite value per customer
        }
    }
}
