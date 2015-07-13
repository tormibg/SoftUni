using System;
using SuperRpgGame.Interfaces;

namespace SuperRpgGame
{
    public abstract class Character : GameObject, ICharacter
    {
        public int Damage { get; set; }
        private string name;
        public void Attack(Character enemy)
        {
            enemy.Health -= this.Damage;
        }

        public int Health { get; set; }
        public string Name {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "name cannot be empty");
                }
                this.name = value;
            }
        }
        public Position Position { get; private set; }

        protected Character(Position position, char objSymbol, int damage, int health, string name) : base(position, objSymbol)
        {
            this.Damage = damage;
            this.Health = health;
            this.Name = name;
        }
    }
}