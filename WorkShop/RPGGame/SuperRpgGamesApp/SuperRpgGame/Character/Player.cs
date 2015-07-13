using System.Collections.Generic;
using SuperRpgGame.Interfaces;
using SuperRpgGame.Items;

namespace SuperRpgGame
{
    public class Player : Character, IPlayer
    {



        public Player(Position position, char objSymbol, string name, PlayerRace race)
            : base(position, objSymbol, 0, 0, name)
        {
            this.Race = race;
            this.SetPlayerStats();

        }

        private void SetPlayerStats()
        {
            switch (this.Race)
            {
                case PlayerRace.ArchAngel:
                    this.Damage = 200;
                    this.Health = 300;
                    break;
                    case PlayerRace.Elf:
                    this.Damage = 200;
                    this.Health = 400;
                    break;
                    case PlayerRace.Hulk:
                    this.Damage = 200;
                    this.Health = 500;
                    break;
                    case PlayerRace.Human:
                    this.Damage = 200;
                    this.Health = 600;
                    break;
            }
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Item> Inventory { get; private set; }

        public void AddItemToInventory(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void Heal()
        {
            throw new System.NotImplementedException();
        }

        public int Experience { get; private set; }

        public void LevelUp()
        {
            throw new System.NotImplementedException();
        }

        public PlayerRace Race { get; private set; }
    }
}