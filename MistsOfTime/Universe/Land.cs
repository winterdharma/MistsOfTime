namespace MistsOfTime.Universe
{
    internal class Land
    {
        internal Land()
        {
            Population = InitializePop();
            Trees = InitializeTrees();
            Animals = InitializeAnimals();
            Farms = InitializeFarms();
        }

        internal int Population { get; set; }
        internal int Trees { get; set; }
        internal int Animals { get; set; }
        internal int Farms { get; set; }

        private int InitializePop()
        {
            int check = Game.Random.Next(1, 100);
            if (check > 75)
                return Game.Random.Next(10, 1000);
            else return 0;
        }

        private int InitializeTrees()
        {
            int check = Game.Random.Next(1, 100);
            if (check < 50)
                return Game.Random.Next(1000, 5000);
            else if (check < 90)
                return Game.Random.Next(100, 1000);
            else
                return Game.Random.Next(1, 100);
        }

        private int InitializeAnimals()
        {
            return Game.Random.Next(100, 1000) + (Trees / 50)*2;
        }

        private int InitializeFarms()
        {
            if (Population > 0)
            {
                return Population / 4;
            }
            else return 0;

        }
    }
}