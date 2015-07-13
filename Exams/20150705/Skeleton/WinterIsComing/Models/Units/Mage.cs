namespace WinterIsComing.Models.Units
{
    public class Mage : Unit
    {
        //o	Default stats: 80 attack points, 80 health points, 40 defense, 120 energy, range 2
        private const int MageAttackPoints = 80;
        private const int MageHealtPoints = 80;
        private const int MageDefensePoints = 40;
        private const int MageEnergyPoints = 120;
        private const int MageRangeAttack = 2;

        public Mage(int x, int y, string name)
            : base(x, y, name, MageRangeAttack, MageAttackPoints, MageHealtPoints, MageDefensePoints, MageEnergyPoints)
        {
        }
    }
}