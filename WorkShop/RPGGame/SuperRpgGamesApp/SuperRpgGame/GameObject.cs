using System;
using SuperRpgGame.Exceptions;

namespace SuperRpgGame
{
    public abstract class GameObject
    {
        private Position position;
        private char objSymbol;

        protected GameObject(Position position, char objSymbol)
        {
            this.Position = position;
            this.ObjSymbol = objSymbol;
        }

        public Position Position {
            get { return this.position; }

            set
            {
                if (value.X < 0 || value.Y < 0)
                {
                    throw new ObjOutOfBoundsException("Specified cordinates are outside map.");
                }
                this.position = value;
            }
        }

        public char ObjSymbol {
            get { return this.objSymbol; }
            set
            {
                if (!char.IsUpper(value))
                {
                    throw new ArgumentNullException("");
                }
                this.objSymbol = value;
            }
        }
    }
}