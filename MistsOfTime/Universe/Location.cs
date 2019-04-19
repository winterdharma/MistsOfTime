namespace MistsOfTime.Universe
{
    public class Location
    {
        public Location(string coords)
        {
            Coords = coords;
        }

        public string Coords { get; set; }

        public override string ToString()
        {
            return Coords;
        }
    }
}