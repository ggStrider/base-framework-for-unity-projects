using ggStrider.Shared.Scripts.Runtime.Core.Misc;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Audio.Data
{
    [CreateAssetMenu(fileName = "New Audio Entry", menuName = ConstKeys.SO_BRANCH + "Audio/Entry")]
    public class AudioEntrySO : ScriptableObject
    {
        [field: SerializeField] public AudioClip Clip { get; private set; }
        [field: SerializeField] public string Key { get; private set; }

        [field: Space]
        [field: Range(0f, 1f)]
        [field: SerializeField] public float Volume { get; private set; } = 1f;

        [field: Range(-3f, 3f)]
        [field: SerializeField] public float MinPitch { get; private set; } = 0.95f;

        [field: Range(-3f, 3f)]
        [field: SerializeField] public float MaxPitch { get; private set; } = 1.05f;

        [field: Space]
        [field: SerializeField] public bool Loop { get; private set; } = false;

        public float GetPitch()
        {
            return Random.Range(MinPitch, MaxPitch);
        }
    }
}