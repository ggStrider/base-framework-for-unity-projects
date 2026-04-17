using ggStrider.Shared.Scripts.Runtime.Core.Misc;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Scenes
{
    [CreateAssetMenu(fileName = "New Scene Card", menuName = ConstKeys.SO_BRANCH + "Scenes/Card")]
    public class SceneCard : ScriptableObject
    {
        [field: SerializeField] public string SceneFileName { get; private set; } = "kek";
    }
}