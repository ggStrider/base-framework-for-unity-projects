using System;
using ggStrider.Shared.Scripts.Runtime.Core.Extensions;
using ggStrider.Shared.Scripts.Runtime.Core.Misc;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens.Additional
{
    [CreateAssetMenu(fileName = "New Advices For Loading Screen",
        menuName = ConstKeys.SO_BRANCH + "UI/Loading Screens/Advices")]
    public class AdvicesForLoadingScreenSO : ScriptableObject
    {
        [field: SerializeField] public string[] Advices { get; private set; }
        [field: SerializeField] public SpriteWithSize[] SpriteWithSizes { get; private set; }

        public SpriteWithSize GetRandomSpriteWithSize()
        {
            return SpriteWithSizes.GetRandomElement();
        }

        public string GetRandomAdvice()
        {
            return Advices.GetRandomElement();
        }
    }

    [Serializable]
    public class SpriteWithSize
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public Vector2 SizeInCanvas { get; private set; } = new Vector2(100, 100);
    }
}