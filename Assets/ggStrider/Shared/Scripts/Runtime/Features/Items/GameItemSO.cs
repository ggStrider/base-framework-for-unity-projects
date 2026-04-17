using ggStrider.Shared.Scripts.Runtime.Core.Misc;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Features.Items
{
    [CreateAssetMenu(fileName = "New Game Item", menuName = ConstKeys.SO_BRANCH + "Game Item")]
    public class GameItemSO : ScriptableObject
    {
        [field: SerializeField] public string ItemName { get; private set; } = "Unnamed";
        
        [field: Min(1)]
        [field: SerializeField] public int MaxStack { get; private set; } = 1;
    }
}