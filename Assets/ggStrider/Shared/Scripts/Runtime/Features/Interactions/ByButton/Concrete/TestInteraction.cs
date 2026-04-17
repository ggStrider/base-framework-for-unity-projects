using ggStrider.Shared.Scripts.Runtime.Core.Utils;
using ggStrider.Shared.Scripts.Runtime.Features.Interactions.ByButton.Base;

namespace ggStrider.Shared.Scripts.Runtime.Features.Interactions.ByButton.Concrete
{
    public class TestInteraction : BaseMonoInteract
    {
        public override InteractResults OnInteract(InteractContext context)
        {
            ggDebug.Log($"Interact with phase: {context.InputPhase.ToString()}",
                LogCategory.General);

            return InteractResults.Success;
        }
    }
}