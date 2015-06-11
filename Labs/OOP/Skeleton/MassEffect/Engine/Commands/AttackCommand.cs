using System;
using System.Linq;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string atShipName = commandArgs[1];
            string deShipName = commandArgs[2];

            IStarship attShip = null;
            IStarship defShip = null;

            attShip = this.GameEngine.Starships.First(x => x.Name == atShipName);
            defShip = this.GameEngine.Starships.First(x => x.Name == deShipName);

            this.ProcessStarshipBattle(attShip, defShip);
        }

        private void ProcessStarshipBattle(IStarship attShip, IStarship defShip)
        {
            base.ValidateAlive(attShip);
            base.ValidateAlive(defShip);

            if (attShip.Location.Name != defShip.Location.Name)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            IProjectile attack = attShip.ProduceAttack();
            defShip.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked, attShip.Name, defShip.Name);

            if (defShip.Shields < 0)
            {
                defShip.Shields = 0;
            }
            if (defShip.Health <= 0)
            {
                defShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, defShip.Name);
            }
        }
    }
}
