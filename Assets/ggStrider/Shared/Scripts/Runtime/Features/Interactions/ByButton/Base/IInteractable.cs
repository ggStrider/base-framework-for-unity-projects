namespace ggStrider.Shared.Scripts.Runtime.Features.Interactions.ByButton.Base
{
    public interface IInteractable
    {
        public int InteractionPriority { get; set; }
        public bool IsInteractable { get; set; }
        public bool BlocksInteractionPropagation { get; set; }
        
        public InteractResults TryInteract(InteractContext context);
    }
}