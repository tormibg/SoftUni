using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using SuperRpgGame.Attributes;
using SuperRpgGame.Interfaces;
using SuperRpgGame.Items;

namespace SuperRpgGame.Engine
{
    public class SuperEngine
    {
        private const int MathWudth = 10;
        private const int MapHeight = 10;
        private const int InitialNumberOfEnemies = 10;

        private static readonly Random Rand = new Random();

        private readonly IInputReader reader;
        private readonly IRenderer renderer;

        private readonly IList<ICharacter> characters;
        private readonly IList<Item> items;
        private IPlayer player;

        private readonly string[] characterNames =
        {
            "1-q",
            "2-q",
            "3-q",
            "4-q",
            "5-q",
            "6-q",
        };
        
        public SuperEngine(IInputReader reader, IRenderer renderer)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.characters = new List<ICharacter>();
            this.items = new List<Item>();
        }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            this.IsRunning = true;

            var playerName = GetPlayerName();
            PlayerRace race = GetPlayerrace();

            this.player = new Player(new Position(0,0), 'P',playerName,PlayerRace.Human);

            this.PopulateEnemies();
            this.Populateitems();

            while (IsRunning)
            {
                string command = this.reader.ReadLine();
                this.ExecuteCommand(command);
            }
        }

        private void Populateitems()
        {
            throw new NotImplementedException();
        }

        private Character CreateEnemy()
        {
            int currentX = Rand.Next(1, MathWudth);
            int currentY = Rand.Next(1, MapHeight);

            bool containsEnemy = this.characters.Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            while (containsEnemy)
            {
                currentX = Rand.Next(1, MathWudth);
                currentY = Rand.Next(1, MapHeight);
                containsEnemy = this.characters.Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }
            int nameIndex = Rand.Next(0, characterNames.Length);
            string name = characterNames[nameIndex];

            var enemyTypes =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof (EnemyAttribute))).ToArray();

            var type = enemyTypes[Rand.Next(0, enemyTypes.Length)];

            ICharacter character = Activator.CreateInstance(type, new Position(currentY, currentY), name) as ICharacter;

            return character;
        }

        private void PopulateEnemies()
        {

            for (int i = 0; i < InitialNumberOfEnemies; i++)
            {
                
            }

        }

        private PlayerRace GetPlayerrace()
        {
            this.renderer.WriteLine("Choice a race :");
            string choice = reader.ReadLine();
            PlayerRace race = (PlayerRace)(int.Parse(choice));
            return race;
        }

        private string GetPlayerName()
        {
            this.renderer.WriteLine("enter name");
            string playerName = this.reader.ReadLine();
            while (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = this.reader.ReadLine();
            }
            return playerName;
        }

        private void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "help":
                    this.ExecuteHelpCommand();
                    break;
                case"map":
                    break;
                case "left":
                    break;
                case "right":
                    break;
                case "up":
                    break;
                case "down":
                    break;
                case "status":
                    break;
                case "enemies":
                    break;
                case "clear":
                    this.renderer.Clear();
                    break;
                case "exit":
                    this.IsRunning = false;
                    this.renderer.WriteLine("Bye");
                    break;
            }
        }

        private void ExecuteHelpCommand()
        {
            string helpinfo = File.ReadAllText(@"../../HelpInfo.txt");
          this.renderer.WriteLine(helpinfo);
        }

 
    }
}