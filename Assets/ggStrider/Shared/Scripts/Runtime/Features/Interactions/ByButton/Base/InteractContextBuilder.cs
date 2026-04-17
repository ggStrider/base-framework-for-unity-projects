using UnityEngine.InputSystem;

namespace ggStrider.Shared.Scripts.Runtime.Features.Interactions.ByButton.Base
{
    public class InteractContextBuilder
    {
        private InteractContext _current = default;

        public InteractContextBuilder SetInputPhase(InputActionPhase to)
        {
            _current.InputPhase = to;
            return this;
        }

        public InteractContext Build()
        {
            var toReturn = _current;
            _current = default;

            return toReturn;
        }
    }
}