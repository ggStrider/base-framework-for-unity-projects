using System;

namespace ggStrider.Shared.Scripts.Runtime.Core.Inputs.Maps
{
    public abstract class BaseInputMap : IDisposable
    {
        public void Initialize(PlayerInputActionsMap playerInputActionsMap) 
        {
            PlayerInputActionsMap = playerInputActionsMap;
        }

        protected PlayerInputActionsMap PlayerInputActionsMap; 
        
        public abstract void Subscribe();
        public abstract void Unsubscribe();

        public virtual void Dispose()
        {
            Unsubscribe();
        }
    }
}