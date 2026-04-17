using ggStrider.Shared.Scripts.Runtime.Core.Misc;
using UnityEngine;
using UnityEngine.Audio;

namespace ggStrider.Shared.Scripts.Runtime.Core.Audio.Data
{
    [CreateAssetMenu(fileName = "New Audio Mixer Groups", menuName = ConstKeys.SO_BRANCH +
                                                                     "Audio/Audio Mixer Groups")]
    public class AudioMixerGroupsSO : ScriptableObject
    {
        [field: SerializeField] public AudioMixer Mixer { get; private set; }

        [field: Space]
        [field: SerializeField] public AudioMixerGroup Master { get; private set; }
        [field: SerializeField] public AudioMixerGroup Music { get; private set; }
        [field: SerializeField] public AudioMixerGroup Sfx { get; private set; }

        [field: Space]
        [field: SerializeField] public string MasterVolumeParam { get; private set; } = "MasterVolume";
        [field: SerializeField] public string MusicVolumeParam { get; private set; } = "MusicVolume";
        [field: SerializeField] public string SfxVolumeParam { get; private set; } = "SfxVolume";

        public void SetMasterVolume(float normalized)
        {
            SetVolume(MasterVolumeParam, normalized);
        }

        public void SetMusicVolume(float normalized)
        {
            SetVolume(MusicVolumeParam, normalized);
        }

        public void SetSfxVolume(float normalized)
        {
            SetVolume(SfxVolumeParam, normalized);
        }

        public void MuteAll(bool mute)
        {
            Mixer.SetFloat(MasterVolumeParam, mute ? -80f : 0f);
        }

        private void SetVolume(string mixerGroupParam, float normalized)
        {
            var db = normalized > 0f
                ? Mathf.Log10(normalized) * 20f
                : -80f;

            Mixer.SetFloat(mixerGroupParam, db);
        }
    }
}