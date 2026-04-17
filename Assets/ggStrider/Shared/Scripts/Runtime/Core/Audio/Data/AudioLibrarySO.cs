using System.Collections.Generic;
using System.Linq;
using ggStrider.Shared.Scripts.Runtime.Core.Misc;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Audio.Data
{
    [CreateAssetMenu(fileName = "New Audio Library", menuName = ConstKeys.SO_BRANCH + "Audio/Library")]
    public class AudioLibrarySO : ScriptableObject
    {
        [SerializeField] private AudioEntrySO[] _entries;

        private Dictionary<string, AudioEntrySO> _lookUp;

        public AudioEntrySO Get(string key)
        {
            if (_lookUp == null)
            {
                _lookUp = _entries.ToDictionary(e => e.Key);
            }

            return _lookUp.GetValueOrDefault(key);
        }
    }
}