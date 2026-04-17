using ggStrider.Shared.Scripts.Runtime.Core.Utils.Serializators;
using UnityEditor;

namespace ggStrider.Shared.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(InterfaceReference<>), true)]
    public class InterfaceReferenceDrawer : InterfaceDrawer
    {
        protected override bool AllowSceneObjects => true;
    }
}