using ggStrider.Shared.Scripts.Runtime.Core.Utils.Serializators;
using UnityEditor;

namespace ggStrider.Shared.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(PrefabInterfaceReference<>), true)]
    public class PrefabInterfaceReferenceDrawer : InterfaceDrawer
    {
        protected override bool AllowSceneObjects => false;
    }
}