using System;

namespace GalacticGPS
{
    class GalacticGPS
    {
        static void Main()
        {
            try
            {
                Location newLoc = new Location(18.037986, 28.870097, Planet.Earth);
                Console.WriteLine(newLoc);
                //Location newLoc1 = new Location(91.0054, -182.054534, Planet.Venus);
                //Console.WriteLine(newLoc1);
                Location newLoc1 = new Location(-89.0054, 182.054534, Planet.Venus);
                Console.WriteLine(newLoc1);
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine(ex.Message)
                ;
            }
        }
    }
}
