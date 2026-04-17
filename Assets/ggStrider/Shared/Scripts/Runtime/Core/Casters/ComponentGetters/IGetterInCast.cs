using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Casters.ComponentGetters
{
    public interface IGetterInCast
    {
        public T GetFirst<T>(Vector3 origin, Vector3 direction);
        public T[] GetInArea<T>(Vector3 origin, Vector3 direction);

        // TODO
        public void DrawGizmos()
        {
        }
    }
}