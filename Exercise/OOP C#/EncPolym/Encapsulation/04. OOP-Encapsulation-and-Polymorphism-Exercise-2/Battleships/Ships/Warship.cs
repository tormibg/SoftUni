namespace Battleships.Ships
{
    public class Warship : Battleship
    {
        private string name;
        private double lengthInMeters;
        private double volume;

        public Warship(string name, double lengthInMeters, double volume)
            : base(name, lengthInMeters, volume)
        {
        }

        public override string Attack(Ship targetShip)
        {
            this.DestroyTarget(targetShip);
            return "Warship destroy your ship !!!";
        }
    }
}
