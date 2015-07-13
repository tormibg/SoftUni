using System.Collections.Generic;
using SuperRpgGame.Items;

namespace SuperRpgGame.Interfaces
{
    public interface ICollect
    {
        IEnumerable<Item> Inventory { get; }

        void AddItemToInventory(Item item);
    }
}