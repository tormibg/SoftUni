namespace SuperRpgGame.Interfaces
{
    public interface IPlayer : ICharacter, IMoveable, ICollect, IHeal, IExperienceGainable
    {
        PlayerRace Race { get; }
    }
}