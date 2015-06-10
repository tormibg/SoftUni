using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locatName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships.Any(x => x.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new DuplicaShipException(Messages.DuplicateShipName);
            }
            var location = this.GameEngine.Galaxy.GetStarSystemByName(locatName);
            StarshipType shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            var newShip =  GameEngine.ShipFactory.CreateShip(shipType, shipName, location);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enchancentType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);

                Enhancement enhancement = null;

                enhancement = GameEngine.EnhancementFactory.Create(enchancentType);

                newShip.AddEnhancement(enhancement);
            }

            GameEngine.Starships.Add(newShip);

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
