using System;
using ggStrider.Shared.Scripts.Runtime.Core.Extensions;
using ggStrider.Shared.Scripts.Runtime.Features.Items;

namespace ggStrider.Shared.Scripts.Runtime.Core.Data
{
    [Serializable]
    public struct GameItem
    {
        public GameItemSO Item;
        public int Amount;
       
        public GameItem(GameItemSO gameItem, int amount)
        {
            Item = gameItem;
            Amount = MathInt.Clamp(amount, 0, gameItem.MaxStack);
        }
    
        public bool CanAdd() => Amount < Item.MaxStack;
        public int HowMuchCanAdd() => Item.MaxStack - Amount;
        public GameItem WithAmount(int newAmount) => new GameItem(Item, newAmount);
    }
}