using MistsOfTime.Assets;
using System.Collections.Generic;

namespace MistsOfTime.Universe
{
    public class Location
    {
        public Location(int x, int y, string name)
        {
            Coords = "[" + x + ", " + y + "]";
            X = x;
            Y = y;
            Name = name;
            Description = new List<string>(LocationData.BlankTerrain); 
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Coords { get; set; }
        public string Name { get; set; }
        public List<string> Description { get; set; }

        public override string ToString()
        {
            return Coords;
        }
    }
}