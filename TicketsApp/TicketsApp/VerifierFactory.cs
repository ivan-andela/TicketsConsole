using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsConsole;

namespace TicketsApp
{
    public class VerifierFactory
    {
        private List<Event> _events;
        public VerifierFactory(List<Event> events)
        {
            _events = events;
        }
        public ICustomerEventVerifier Create(NotificationType notificationType)
        {

            switch (notificationType)
            {
                case NotificationType.SameCity:
                    return new SameCityVerifier();
                case NotificationType.CloseToBirthDay:
                    return new CloseToBirthDayVerifier();
                case NotificationType.CloseToCustomer:
                    return new CustomerEventDistanceVerifier(_events, new LocalCachedDistanceProvider(new DistanceProvider()));
            }

            return null;
        }
    }
}
