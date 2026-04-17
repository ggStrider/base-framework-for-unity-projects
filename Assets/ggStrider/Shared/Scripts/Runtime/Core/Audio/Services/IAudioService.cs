namespace ggStrider.Shared.Scripts.Runtime.Core.Audio.Services
{
    public interface IAudioService
    {
        void PlaySfx(string key);
        void PlayMusic(string key);
        
        void StopMusic();
        
        void SetSfxVolume(float volume);
        void SetMusicVolume(float volume);
        
        void MuteAll(bool mute);
    }
}