using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistsOfTime.Universe
{
    public class World
    {
        private int _height = 10;
        private int _width = 10;

        public World(int? x = null, int? y = null)
        {
            if (x != null)
                _width = (int)x;
            if (y != null)
                _height = (int)y;

            Locations = InitializeWorld();
        }

        public Dictionary<string, Location> Locations { get; set; }

        private Dictionary<string, Location> InitializeWorld()
        {
            var locs = new Dictionary<string, Location>();

            for(int x = 0; x < _width; x++)
            {
                for(int y = 0; y < _height; y++)
                {
                    string key = "[" + x + ", " + y + "]";
                    locs[key] = new Location(key);
                }
            }

            return locs;
        }

        internal Location GetStartingLocation()
        {
            string startKey = "[" + _width / 2 + ", " + _height / 2 + "]";
            return Locations[startKey];
        }
    }
}
