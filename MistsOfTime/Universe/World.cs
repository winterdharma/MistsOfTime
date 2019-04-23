using MistsOfTime.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistsOfTime.Universe
{
    internal class World
    {
        private int _height = 10;
        private int _width = 10;

        internal World(int? x = null, int? y = null)
        {
            if (x != null)
                _width = (int)x;
            if (y != null)
                _height = (int)y;

            Regions = InitializeWorld();
        }

        internal Dictionary<string, Region> Regions { get; set; }

        internal bool MoveNorth(Region current, out Region newPlace)
        {
            newPlace = current;
            int newY = current.Y + 1;
            if (newY < _height)
            {
                newPlace = Regions[MakeKey(current.X, newY)];
                return true;
            }
            else
                return false;
        }

        internal bool MoveEast(Region current, out Region newPlace)
        {
            newPlace = current;
            int newX = current.X + 1;
            if (newX < _width)
            {
                newPlace = Regions[MakeKey(newX, current.Y)];
                return true;
            }
            else
                return false;
        }

        internal bool MoveSouth(Region current, out Region newPlace)
        {
            newPlace = current;
            int newY = current.Y - 1;
            if (newY > -1)
            {
                newPlace = Regions[MakeKey(current.X, newY)];
                return true;
            }
            else
                return false;
        }

        internal bool MoveWest(Region current, out Region newPlace)
        {
            newPlace = current;
            int newX = current.X - 1;
            if (newX > -1)
            {
                newPlace = Regions[MakeKey(newX, current.Y)];
                return true;
            }
            else
                return false;
        }

        internal Region GetStartingLocation()
        {
            string startKey = "[" + _width / 2 + ", " + _height / 2 + "]";
            return Regions[startKey];
        }


        #region Helper Methods
        private Dictionary<string, Region> InitializeWorld()
        {
            var locs = new Dictionary<string, Region>();
            var names = new List<string>(LocationData.placeNames);
            int i = 0;
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    string key = "[" + x + ", " + y + "]";
                    locs[key] = new Region(x, y, names[i]);
                    i++;
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
