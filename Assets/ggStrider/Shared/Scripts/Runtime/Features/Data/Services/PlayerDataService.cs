using Zenject;

using ggStrider.Shared.Scripts.Runtime.Core.Data;
using ggStrider.Shared.Scripts.Runtime.Core.Data.Services;
using ggStrider.Shared.Scripts.Runtime.Core.Extensions;
using ggStrider.Shared.Scripts.Runtime.Features.Items;

namespace ggStrider.Shared.Scripts.Runtime.Features.Data.Services
{
    public class PlayerDataService : IPlayerDataService
    {
        [Inject]
        public PlayerDataService(PlayerData playerData)
        {
            _playerData = playerData;
        }
        
        private readonly PlayerData _playerData;
        
        public bool Contains(GameItemSO item)
        {
            return GetItemIndex(item) != -1;
        }

        /// <summary>
        /// Searching for first slot with <see cref="item"/>, if exists -> adds
        /// amount up to item.MaxStack. If slot is full -> doesnt add in another slot.
        /// If there are no slot with <see cref="item"/> -> creates new slot with this item 
        /// </summary>
        public bool TryAdd(GameItemSO item, int amount, out int howMuchAdded)
        {
            howMuchAdded = 0;
            var itemIndex = GetItemIndex(item);
    
            if (itemIndex == -1)
            {
                var canAdd = MathInt.Min(amount, item.MaxStack);
                _playerData.AddItem(new GameItem(item, canAdd));
                howMuchAdded = canAdd;
                return howMuchAdded == amount;
            }

            var current = _playerData.GameItems[itemIndex];
            if (!current.CanAdd()) return false;

            var toAdd = MathInt.Min(current.HowMuchCanAdd(), amount);
            _playerData.SetItem(itemIndex, current.WithAmount(current.Amount + toAdd));

            howMuchAdded = toAdd;
            return howMuchAdded == amount;
        }

        private int GetItemIndex(GameItemSO item)
        {
            for (int i = 0; i < _playerData.GameItems.Count; i++)
            {
                if (item == _playerData.GameItems[i].Item)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}