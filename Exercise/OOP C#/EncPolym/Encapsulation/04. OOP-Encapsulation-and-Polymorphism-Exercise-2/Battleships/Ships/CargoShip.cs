namespace Battleships.Ships
{
    public class CargoShip : Ship
    {
        private string name;
        private double lengthInMeters;
        private double volume;

        public CargoShip(string name, double lengthInMeters, double volume)
            : base(name, lengthInMeters, volume)
        {
        }
    }
}
