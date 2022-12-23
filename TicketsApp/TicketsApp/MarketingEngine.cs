using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsConsole;

namespace TicketsApp
{
    public class MarketingEngine
    {
        private List<Event> _event;
        VerifierFactory _factory;
        public MarketingEngine(List<Event> events, VerifierFactory factory)
        {
            _event = events;
            _factory = factory;
        }

        public void SendCustomerNotifications(Customer customer, NotificationType notificationType = NotificationType.SameCity)
        {
            var verifier = _factory.Create(notificationType);
            foreach (var e in _event)
            {
                if (verifier.Verify(customer, e))
                {
                    SendCustomerNotification(customer, e);
                }
            }
        }

        private static void SendCustomerNotification(Customer customer, Event e)
        {
            Console.WriteLine($"{customer.Name} from {customer.City} event {e.Name} at {e.Date}");
        }
    }
}
