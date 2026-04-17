using ggStrider.Shared.Scripts.Runtime.Core.Audio.Data;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Audio.Services
{
    public class AudioService : BaseAudioService
    {
        public AudioService(AudioLibrarySO library, AudioMixerGroupsSO mixerGroups, AudioSource musicSource, AudioSource sfxSource) : base(library, mixerGroups, musicSource, sfxSource)
        {
        }
    }
}