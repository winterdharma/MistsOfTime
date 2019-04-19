using MistsOfTime.Assets;

namespace MistsOfTime.Universe
{
    public class Location
    {
        public Location(int x, int y)
        {
            Coords = "[" + x + ", " + y + "]";
            X = x;
            Y = y;
            Description = LocationStrings.BlankTerrain; 
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Coords { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Coords;
        }
    }
}