using System;

namespace SuperRpgGame.Items
{
    public class Beer : Item
    {

        public Beer(Position position, char itemSymbol, BeerSize beerSize)
            : base(position, itemSymbol)
        {
            this.BeerSize = beerSize;
        }

        private BeerSize BeerSize { get; set; }

        public int HealtRestore {
            get { return (int) this.BeerSize; }
        }
    }
}