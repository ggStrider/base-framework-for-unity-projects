using System;
using System.Collections.Generic;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private List<GameItem> _gameItems = new List<GameItem>();
    
        public IReadOnlyList<GameItem> GameItems => _gameItems;
    
        public void AddItem(GameItem item) 
            => _gameItems.Add(item);
        
        public void SetItem(int index, GameItem item)
            => _gameItems[index] = item;
    }
}