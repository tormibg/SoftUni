namespace WinterIsComing.Models.Units
{
    public class IceGiant : Unit
    {
        //o	Default stats: 150 attack points, 300 health points, 60 defense, 50 energy, range 1
        private const int IceGiantAttackPoints = 150;
        private const int IceGiantHealtPoints = 300;
        private const int IceGiantDefensePoints = 60;
        private const int IceGiantEnergyPoints = 50;
        private const int IceGiantRangeAttack = 1;

        public IceGiant(int x, int y, string name)
            : base(x, y, name, IceGiantRangeAttack, IceGiantAttackPoints, IceGiantHealtPoints, IceGiantDefensePoints, IceGiantEnergyPoints)
        {
        }
    }
}