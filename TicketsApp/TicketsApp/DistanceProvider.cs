using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicketsConsole.DistanceProvider;

namespace TicketsConsole
{
    public class DistanceProvider : IDistanceProvider
    {
        public record City(string Name, int X, int Y);
        public static readonly IDictionary<string, City> Cities = new Dictionary<string, City>()
        {
        { "New York", new City("New York", 3572, 1455) },
        { "Los Angeles", new City("Los Angeles", 462, 975) },
        { "San Francisco", new City("San Francisco", 183, 1233) },
        { "Boston ", new City("Boston", 3778, 1566) },
        { "Chicago ", new City("Chicago", 2608, 1525) },
        { "Washington ", new City("Washington", 3358, 1320) },
        };
        public int GetDistance(string cityA, string cityB)
        {
            if (Cities.ContainsKey(cityA) && Cities.ContainsKey(cityB))
            {
                return CalcDistance(Cities[cityA], Cities[cityB]);
            }

            return 0;
        }

        private int CalcDistance(City city1, City city2)
        {
            return Math.Abs(city1.X - city2.X) + Math.Abs(city1.Y - city2.Y);
        }
    }
}
