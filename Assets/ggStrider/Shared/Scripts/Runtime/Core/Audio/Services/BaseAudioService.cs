using System;
using ggStrider.Shared.Scripts.Runtime.Core.Audio.Data;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Audio.Services
{
    [Serializable]
    public struct AudioServiceDependencies
    {
        public AudioLibrarySO Library;
        public AudioMixerGroupsSO MixerGroups;
        public AudioSource MusicSource;
        public AudioSource SfxSource;
    }
    
    public abstract class BaseAudioService : IAudioService
    {
        protected readonly AudioLibrarySO Library;
        protected readonly AudioMixerGroupsSO MixerGroups;
        protected readonly AudioSource MusicSource;
        protected readonly AudioSource SfxSource;

        protected BaseAudioService(AudioServiceDependencies dependencies)
        {
            Library = dependencies.Library;
            MixerGroups = dependencies.MixerGroups;

            MusicSource = dependencies.MusicSource;
            MusicSource.outputAudioMixerGroup = dependencies.MixerGroups.Music;

            SfxSource = dependencies.SfxSource;
            SfxSource.outputAudioMixerGroup = dependencies.MixerGroups.Sfx;
        }

        public virtual void PlaySfx(string key)
        {
            var entry = Library.Get(key);
            if (entry == null)
            {
                Debug.LogWarning($"AudioService: sfx key '{key}' not found");
                return;
            }

            SfxSource.pitch = entry.GetPitch();
            SfxSource.PlayOneShot(entry.Clip, entry.Volume);
        }

        public virtual void PlayMusic(string key)
        {
            var entry = Library.Get(key);
            if (entry == null)
            {
                Debug.LogWarning($"AudioService: music key '{key}' not found");
                return;
            }

            if (MusicSource.clip == entry.Clip && MusicSource.isPlaying)
                return;

            MusicSource.clip = entry.Clip;
            MusicSource.volume = entry.Volume;
            MusicSource.pitch = entry.GetPitch();
            MusicSource.loop = entry.Loop;
            MusicSource.Play();
        }

        public virtual void StopMusic() => MusicSource.Stop();

        public virtual void SetSfxVolume(float volume) => MixerGroups.SetSfxVolume(volume);
        public virtual void SetMusicVolume(float volume) => MixerGroups.SetMusicVolume(volume);
        public virtual void MuteAll(bool mute) => MixerGroups.MuteAll(mute);
    }
}