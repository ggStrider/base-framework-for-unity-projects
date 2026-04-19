using ggStrider.Shared.Scripts.Runtime.Core.Utils;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Misc
{
    /// <summary>
    /// Centralized storage for constant tags, layers, and asset menu paths.
    /// Eliminates magic strings and simplifies maintenance.
    /// </summary>
    /// <example>
    /// <code>
    /// // Tags
    /// gameObject.CompareTag(ConstKeys.Tags.Player);
    ///
    /// // Layers
    /// Physics.Raycast(origin, dir, dist, ConstKeys.Layers.Player.LayerMask);
    /// gameObject.layer = ConstKeys.Layers.Player.LayerIndex;
    /// </code>
    /// </example>
    public static class ConstKeys
    {
        public const string SO_BRANCH = "ggStrider/";
        
        #region Tags

        public static class Tags
        {
            public const string Player = "Player";
        }

        #endregion

        #region Layers

        // TODO: Log if layer is invalid (eg doesnt exist)
        public static class Layers
        {
            public static readonly Layer Player = new(name: "Player", index: 3);

            public readonly struct Layer
            {
                public string Name { get; }
                public int Index { get; }

                public LayerMask Mask { get; }

                public Layer(string name, int index)
                {
                    Name = name;
                    Index = index;
                    Mask = 1 << Index;
                }
            }
        }

        #endregion
    }
}