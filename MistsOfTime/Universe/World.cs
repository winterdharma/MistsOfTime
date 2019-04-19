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

        internal bool MoveNorth(Location current, out Location newPlace)
        {
            newPlace = current;
            int newY = current.Y + 1;
            if (newY < _height)
            {
                newPlace = Locations[MakeKey(current.X, newY)];
                return true;
            }
            else
                return false;
        }

        internal bool MoveEast(Location current, out Location newPlace)
        {
            newPlace = current;
            int newX = current.X + 1;
            if (newX < _width)
            {
                newPlace = Locations[MakeKey(newX, current.Y)];
                return true;
            }
            else
                return false;
        }

        internal bool MoveSouth(Location current, out Location newPlace)
        {
            newPlace = current;
            int newY = current.Y - 1;
            if (newY > -1)
            {
                newPlace = Locations[MakeKey(current.X, newY)];
                return true;
            }
            else
                return false;
        }

        internal bool MoveWest(Location current, out Location newPlace)
        {
            newPlace = current;
            int newX = current.X - 1;
            if (newX > -1)
            {
                newPlace = Locations[MakeKey(newX, current.Y)];
                return true;
            }
            else
                return false;
        }

        internal Location GetStartingLocation()
        {
            string startKey = "[" + _width / 2 + ", " + _height / 2 + "]";
            return Locations[startKey];
        }


        #region Helper Methods
        private Dictionary<string, Location> InitializeWorld()
        {
            var locs = new Dictionary<string, Location>();

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    string key = "[" + x + ", " + y + "]";
                    locs[key] = new Location(x, y);
                }
            }

            return locs;
        }

        private string MakeKey(int x, int y)
        {
            return "[" + x + ", " + y + "]";
        }

        #endregion
    }
}
