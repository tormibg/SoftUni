using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
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
        //create Frigate Normandy Serpent-Nebula ThanixCannon
        public override void Execute(string[] commandArgs)
        {
            string shipTypeString = commandArgs[1];
            string shipName = commandArgs[2];
            string starSystemName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new ShipException(String.Format(Messages.DuplicateShipName));
            }
            
            StarSystem location = this.GameEngine.Galaxy.GetStarSystemByName(starSystemName);
            StarshipType shipType = (StarshipType) Enum.Parse(typeof (StarshipType), shipTypeString);

            IStarship newShip = this.GameEngine.ShipFactory.CreateShip(shipType, shipName,location);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType) Enum.Parse(typeof (EnhancementType), commandArgs[i]);
                Enhancement enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                newShip.AddEnhancement(enhancement);
            }

            this.GameEngine.Starships.Add(newShip);

            Console.WriteLine(Messages.CreatedShip,shipType,shipName);
        }
    }
}
