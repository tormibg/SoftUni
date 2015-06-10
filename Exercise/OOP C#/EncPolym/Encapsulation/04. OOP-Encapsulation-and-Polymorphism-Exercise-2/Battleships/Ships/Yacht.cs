namespace Battleships.Ships
{
    using System;

    public class Yacht : Ship
    {
        private string name;
        private double lengthInMeters;
        private double volume;

        public Yacht(string name, double lengthInMeters, double volume) : base(name, lengthInMeters, volume)
        {
        }
    }
}
