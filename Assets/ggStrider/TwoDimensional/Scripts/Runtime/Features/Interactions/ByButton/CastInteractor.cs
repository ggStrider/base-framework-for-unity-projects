using System;
using ggStrider.Shared.Scripts.Runtime.Features.Interactions.ByButton.Base;
using ggStrider.TwoDimensional.Scripts.Runtime.Core.Casters.ComponentGetters;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ggStrider.TwoDimensional.Scripts.Runtime.Features.Interactions.ByButton
{
    public class CastInteractor : MonoBehaviour
    {
        [SerializeField] private GetterInCircle2D _getter = new GetterInCircle2D(1.5f);
        [SerializeField] private Transform _origin;

        private readonly InteractContextBuilder _interactContextBuilder = new();

        private void TryInteract(InputActionPhase inputPhase)
        {
            var interactables = _getter.GetInArea<IInteractable>(_origin.position, Vector3.zero);
            if (interactables.Length > 1)
            {
                Array.Sort(interactables, (a, b) => a.InteractionPriority.CompareTo(b.InteractionPriority));
            }

            var interactContext = FormInteractContext(inputPhase);
            for (int i = 0; i < interactables.Length; i++)
            {
                interactables[i].TryInteract(interactContext);

                if (interactables[i].BlocksInteractionPropagation)
                    break;
            }
        }

        private InteractContext FormInteractContext(InputActionPhase phase)
        {
            return _interactContextBuilder
                .SetInputPhase(phase)
                .Build();
        }
    }
}