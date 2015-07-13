namespace SuperRpgGame.Interfaces
{
    public interface IAttack
    {
        int Damage { get; }
        void Attack(Character enemy);
    }
}