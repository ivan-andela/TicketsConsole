using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsConsole
{
    public interface IDistanceProvider
    {
        int GetDistance(string cityA, string cityB);
    }
}
