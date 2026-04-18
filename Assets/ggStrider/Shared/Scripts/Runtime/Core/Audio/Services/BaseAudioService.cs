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
        private readonly AudioLibrarySO _library;
        private readonly AudioMixerGroupsSO _mixerGroups;
        private readonly AudioSource _musicSource;
        private readonly AudioSource _sfxSource;

        protected BaseAudioService(AudioServiceDependencies dependencies)
        {
            _library = dependencies.Library;
            _mixerGroups = dependencies.MixerGroups;

            _musicSource = dependencies.MusicSource;
            _musicSource.outputAudioMixerGroup = dependencies.MixerGroups.Music;

            _sfxSource = dependencies.SfxSource;
            _sfxSource.outputAudioMixerGroup = dependencies.MixerGroups.Sfx;
        }

        public virtual void PlaySfx(string key)
        {
            var entry = _library.Get(key);
            if (entry == null)
            {
                Debug.LogWarning($"AudioService: sfx key '{key}' not found");
                return;
            }

            _sfxSource.pitch = entry.GetPitch();
            _sfxSource.PlayOneShot(entry.Clip, entry.Volume);
        }

        public virtual void PlayMusic(string key)
        {
            var entry = _library.Get(key);
            if (entry == null)
            {
                Debug.LogWarning($"AudioService: music key '{key}' not found");
                return;
            }

            if (_musicSource.clip == entry.Clip && _musicSource.isPlaying)
                return;

            _musicSource.clip = entry.Clip;
            _musicSource.volume = entry.Volume;
            _musicSource.pitch = entry.GetPitch();
            _musicSource.loop = entry.Loop;
            _musicSource.Play();
        }

        public virtual void StopMusic() => _musicSource.Stop();

        public virtual void SetSfxVolume(float volume) => _mixerGroups.SetSfxVolume(volume);
        public virtual void SetMusicVolume(float volume) => _mixerGroups.SetMusicVolume(volume);
        public virtual void MuteAll(bool mute) => _mixerGroups.MuteAll(mute);
    }
}