namespace SuperRpgGame.Items
{
    public abstract class Item : GameObject
    {
        protected Item(Position position, char itemSymbol)
            : base(position, itemSymbol)
        {
            this.ItemState = ItemState.Availabe;
        }

        public ItemState ItemState { get; set; }
    }
}