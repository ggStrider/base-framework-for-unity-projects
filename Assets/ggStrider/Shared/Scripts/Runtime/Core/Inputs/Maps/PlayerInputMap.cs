using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ggStrider.Shared.Scripts.Runtime.Core.Inputs.Maps
{
    public class PlayerInputMap : BaseInputMap
    {
        public event Action<Vector2> OnMoveInput;
        
        public event Action<bool> OnJumpInput;
        public event Action<bool> OnSprintInput;
        
        public event Action<InputActionPhase> OnInteractInput;

        public override void Subscribe()
        {
            PlayerInputActionsMap.Player.Move.performed += MoveNotify;
            PlayerInputActionsMap.Player.Move.canceled += MoveNotify;

            PlayerInputActionsMap.Player.Jump.performed += JumpNotify;
            PlayerInputActionsMap.Player.Jump.canceled += JumpNotify;
            
            PlayerInputActionsMap.Player.Sprint.performed += SprintNotify;
            PlayerInputActionsMap.Player.Sprint.canceled += SprintNotify;

            PlayerInputActionsMap.Player.Interact.performed += InteractNotify;
            PlayerInputActionsMap.Player.Interact.canceled += InteractNotify;
        }
        
        public override void Unsubscribe()
        {
            PlayerInputActionsMap.Player.Move.performed -= MoveNotify;
            PlayerInputActionsMap.Player.Move.canceled -= MoveNotify;

            PlayerInputActionsMap.Player.Jump.performed -= JumpNotify;
            PlayerInputActionsMap.Player.Jump.canceled -= JumpNotify;
            
            PlayerInputActionsMap.Player.Sprint.performed -= SprintNotify;
            PlayerInputActionsMap.Player.Sprint.canceled -= SprintNotify;

            PlayerInputActionsMap.Player.Interact.performed -= InteractNotify;
            PlayerInputActionsMap.Player.Interact.canceled -= InteractNotify;
        }

        #region Notifiers

        private void MoveNotify(InputAction.CallbackContext context)
        {
            OnMoveInput?.Invoke(context.ReadValue<Vector2>());
        }

        private void JumpNotify(InputAction.CallbackContext context)
        {
            OnJumpInput?.Invoke(context.performed);
        }
        
        private void SprintNotify(InputAction.CallbackContext context)
        {
            OnSprintInput?.Invoke(context.performed);
        }

        private void InteractNotify(InputAction.CallbackContext context)
        {
            OnInteractInput?.Invoke(context.phase);
        }

        #endregion
    }
}