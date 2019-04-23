using MistsOfTime.Assets;
using System;
using System.Collections.Generic;

namespace MistsOfTime.Universe
{
    internal class Region
    {
        internal Region(int x, int y, string name)
        {
            Coords = "[" + x + ", " + y + "]";
            X = x;
            Y = y;
            Name = name;
            Description = new List<string>(LocationData.BlankTerrain);
            Lands = InitializeLands(10);
        }

        internal int X { get; set; }
        internal int Y { get; set; }
        internal string Coords { get; set; }
        internal string Name { get; set; }
        internal List<string> Description { get; set; }
        internal List<Land> Lands { get; set; }

        public override string ToString()
        {
            return Coords;
        }

        private List<Land> InitializeLands(int numLands)
        {
            var lands = new List<Land>();
            for(int i = 0; i < numLands; i++)
            {
                lands.Add(new Land());
            }
            return lands;
        }
    }
}