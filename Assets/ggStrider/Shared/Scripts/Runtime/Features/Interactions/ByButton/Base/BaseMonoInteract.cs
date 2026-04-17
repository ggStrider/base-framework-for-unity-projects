using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ggStrider.Shared.Scripts.Runtime.Features.Interactions.ByButton.Base
{
    public abstract class BaseMonoInteract : MonoBehaviour, IInteractable
    {
        [field: SerializeField] public int InteractionPriority { get; set; } = 0;
        [field: SerializeField] public bool BlocksInteractionPropagation { get; set; } = false;
        [field: SerializeField] public bool IsInteractable { get; set; } = true;

        [Space]
        [SerializeField] protected InputActionPhase[] AllowedInputPhases = { InputActionPhase.Performed };

        [SerializeField] protected InteractionMode InteractMode = InteractionMode.DisableAfterSuccess;

        protected enum InteractionMode
        {
            DisableAfterSuccess,
            AlwaysActive
        };

        public InteractResults TryInteract(InteractContext context)
        {
            if (!IsInteractable)
                return InteractResults.Failed;

            if (!CanInteractByCurrentButtonState(context))
                return InteractResults.FailedDueButtonState;

            var result = OnInteract(context);
            HandleInteractAllowance(result);

            return result;
        }

        private void HandleInteractAllowance(InteractResults result)
        {
            switch (InteractMode)
            {
                case InteractionMode.DisableAfterSuccess:
                    if (result == InteractResults.Success)
                        IsInteractable = false;

                    break;

                case InteractionMode.AlwaysActive:
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private bool CanInteractByCurrentButtonState(InteractContext context)
        {
            return AllowedInputPhases.Contains(context.InputPhase);
        }

        public abstract InteractResults OnInteract(InteractContext context);

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            // remove duplicates
            AllowedInputPhases = AllowedInputPhases.Distinct().ToArray();
        }
#endif
    }
}