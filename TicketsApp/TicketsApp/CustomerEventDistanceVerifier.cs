using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsConsole
{
    public class CustomerEventDistanceVerifier : ICustomerEventVerifier
    {
        private List<Event> _events;
        private IDistanceProvider _distanceProvider;
        private Customer _currentCustomer;
        public CustomerEventDistanceVerifier(List<Event> events, IDistanceProvider distanceProvider) 
        { 
            _events = events;
            _distanceProvider = distanceProvider;
        }
        public bool Verify(Customer customer, Event e)
        {
            if (customer!=_currentCustomer)
            {
                EnsureEventsForCustomer(customer);
            }

            return _events.IndexOf(e) < 5; //this 5 could be configurable or be part of favorites for customers
        }

        private void EnsureEventsForCustomer(Customer customer)
        {
            _events = _events.OrderBy(e => _distanceProvider.GetDistance(customer.City, e.City)).ToList();
        }
    }
}
