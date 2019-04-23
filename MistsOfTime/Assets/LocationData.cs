using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistsOfTime.Assets
{
    internal class LocationData
    {
        internal static string[] placeNames = new string[]
        {
            "Estertown", "Landhall", "Northburn", "Aldspring", "Stonemoor", "Vertloch", "Stonepine", "Lochmist", "Coldwolf", "Oldlyn",
            "Goldlight", "Snowmount", "Linley", "Aldoak", "Vertdell", "Wyvernmont", "Lightmont", "Whiteston", "Northhedge", "Coastpond",
            "Wolfholt", "Woodmoor", "Foxwall", "Eastness", "Sagebarrow", "Cormount", "Summerwind", "Merrowcliff", "Havenden", "Witchcastle",
            "Ironedge", "Erikeep", "Marblegold", "Aldbarrow", "Estergrass", "Coldelf", "Glasswick", "Waterley", "Barrowlea", "Dorland",
            "Rosepond", "Rosebarrow", "Springgrass", "Swynhollow", "Stonefall", "Highmeadow", "Fallmeadow", "Roseham", "Greenbank", "Erimount",
            "Westlight", "Silvertown", "Mallowbank", "Witchlyn", "Marblemoor", "Jankeep", "Ostlea", "Westviolet", "Brookdale", "Rosegriffin",
            "Rosewood", "Shadowbridge", "Swynness", "Fogcoast", "Eastmill", "Clearsea", "Starrybell", "Wayford", "Westwilde", "Silvermeadow",
            "Woodgate", "Brightmage", "Stonecrest", "Wheatbush", "Greenwater", "Esterwinter", "Fallshore", "Wildewinter", "Whiteton", "Marblelyn",
            "Grassland", "Marblebeach", "Beachpond", "Faywynne", "Crystalmount", "Aldviolet", "Flowergate", "Starryfay", "Grassbarrow", "Marblemere",
            "Freyston", "Merriborough", "Redview", "Freygate", "Aldhaven", "Violettown", "Orbush", "Crystalcrest", "Fogdell", "Mistdell"
        };


        internal static List<string> BlankTerrain = new List<string>
        {
            "'There's nothing more reassuring",
            "  than a place without unpleasant surprises;",
            "And nothing more mind-numbing.'",
            "",
            "This is an unremarkable stretch of grassland."
        };

        internal static string MovedOutOfBounds = "You reached the edge of the world and could go no further.";
    }
}
