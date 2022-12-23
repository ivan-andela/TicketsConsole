using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsConsole
{
    public class LocalCachedDistanceProvider : IDistanceProvider
    {
        Dictionary<string, int> _distances=new Dictionary<string, int>();
        IDistanceProvider _distanceProvider;
        public LocalCachedDistanceProvider(IDistanceProvider distanceProvider)
        {
            _distanceProvider= distanceProvider;
        }
        public int GetDistance(string cityA, string cityB)
        {
            if (_distances.ContainsKey(cityA + "-" + cityB))
            {
                return _distances[cityA + "-" + cityB];
            }
            else if (_distances.ContainsKey(cityB + "-" + cityA))
            {
                return _distances[cityB + "-" + cityA];
            }

            int distance = _distanceProvider.GetDistance(cityA, cityB);
            _distances[cityA + "-" + cityB] = distance;

            return distance;
        }
    }
}
