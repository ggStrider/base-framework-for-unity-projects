using ggStrider.Shared.Scripts.Runtime.Core.Audio.Data;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Audio.Services
{
    public abstract class BaseAudioService : IAudioService
    {
        private readonly AudioLibrarySO _library;
        private readonly AudioMixerGroupsSO _mixerGroups;
        private readonly AudioSource _musicSource;
        private readonly AudioSource _sfxSource;

        protected BaseAudioService(
            AudioLibrarySO library,
            AudioMixerGroupsSO mixerGroups,
            AudioSource musicSource,
            AudioSource sfxSource)
        {
            _library = library;
            _mixerGroups = mixerGroups;

            _musicSource = musicSource;
            _musicSource.outputAudioMixerGroup = mixerGroups.Music;

            _sfxSource = sfxSource;
            _sfxSource.outputAudioMixerGroup = mixerGroups.Sfx;
        }

        public void PlaySfx(string key)
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

        public void PlayMusic(string key)
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

        public void StopMusic() => _musicSource.Stop();

        public void SetSfxVolume(float volume) => _mixerGroups.SetSfxVolume(volume);
        public void SetMusicVolume(float volume) => _mixerGroups.SetMusicVolume(volume);
        public void MuteAll(bool mute) => _mixerGroups.MuteAll(mute);
    }
}