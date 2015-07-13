namespace WinterIsComing.Models.Units
{
    public class Warrior : Unit
    {
        //o	Default stats: 120 attack points, 180 health points, 70 defense, 60 energy, range 1
        private const int WarAttackPoints = 120;
        private const int WarHealtPoints = 180;
        private const int WarDefensePoints = 70;
        private const int WarEnergyPoints = 60;
        private const int WarRangeAttack = 1;

        public Warrior(int x, int y, string name)
            : base(x, y, name, WarRangeAttack, WarAttackPoints, WarHealtPoints, WarDefensePoints, WarEnergyPoints)
        {
        }
    }
}