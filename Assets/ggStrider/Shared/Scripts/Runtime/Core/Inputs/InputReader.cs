using System;
using ggStrider.Shared.Scripts.Runtime.Core.Inputs.Maps;
using ggStrider.Shared.Scripts.Runtime.Core.Utils;
using Zenject;

namespace ggStrider.Shared.Scripts.Runtime.Core.Inputs
{
    public class InputReader : IInitializable, IDisposable
    {
        private PlayerInputActionsMap _playerMap;
        private BaseInputMap _currentMap;

        #region Maps

        public PlayerInputMap PlayerInputMap { get; private set; } = new PlayerInputMap();
        public UIInputMap UIInputMap { get; private set; } = new UIInputMap();

        #endregion

        #region Lifecycle

        public void Initialize()
        {
            _playerMap = new PlayerInputActionsMap();
            GiveDependenciesToAllMaps();

            SwitchMapTo(PlayerInputMap);
            _playerMap.Enable();
        }

        public void Dispose()
        {
            _playerMap.Disable();
            _currentMap?.Unsubscribe();

            // dispose all maps here
            PlayerInputMap?.Dispose();
            UIInputMap?.Dispose();

            _playerMap.Dispose();
        }

        private void GiveDependenciesToAllMaps()
        {
            PlayerInputMap.Initialize(_playerMap);
            UIInputMap.Initialize(_playerMap);
        }

        #endregion

        #region Maps switching

        private void SwitchMapTo(BaseInputMap newMap)
        {
            if (newMap == null)
            {
                ggDebug.Error("why are you trying to change map to null? " +
                              "If you want to disable all maps then use UnsubscribeFromCurrentMap()");

                return;
            }

            if (_currentMap == newMap)
                return;

            _currentMap?.Unsubscribe();

            _currentMap = newMap;
            _currentMap.Subscribe();
        }

        public void SwitchToPlayerMap() => SwitchMapTo(PlayerInputMap);
        public void SwitchToUIMap() => SwitchMapTo(UIInputMap);

        public void UnsubscribeFromCurrentMap() => _currentMap?.Unsubscribe();

        #endregion
    }
}