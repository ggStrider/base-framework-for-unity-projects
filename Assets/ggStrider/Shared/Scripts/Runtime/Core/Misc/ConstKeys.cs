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

        public static class Layers
        {
            public static readonly Layer Player = new(layerName: "Player", layerIndex: 3);

            public readonly struct Layer
            {
                public string LayerName { get; }
                public int LayerIndex { get; }

                public LayerMask LayerMask { get; }

                public Layer(string layerName, int layerIndex)
                {
                    LayerName = layerName;
                    LayerIndex = layerIndex;
                    LayerMask = LayerMask.NameToLayer(layerName);
                    
                    if (LayerMask.value == -1)
                        ggDebug.Error($"[{nameof(ConstKeys)}] Layer \"{layerName}\" not found. Check Edit -> Project Settings -> Tags and Layers");
                }
            }
        }

        #endregion
    }
}