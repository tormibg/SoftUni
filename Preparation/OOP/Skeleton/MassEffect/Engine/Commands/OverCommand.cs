namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class OverCommand : Command
    {
        public OverCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            throw new System.NotImplementedException();
        }
    }
}
