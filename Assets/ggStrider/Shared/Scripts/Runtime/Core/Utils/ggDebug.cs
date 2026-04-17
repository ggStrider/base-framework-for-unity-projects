using System.Diagnostics;

namespace ggStrider.Shared.Scripts.Runtime.Core.Utils
{
    public enum LogCategory
    {
        General,
        Gameplay,
        AI,
        UI,
        Audio,
    }
    
    public static class ggDebug
    {
        [Conditional("LOGS_ENABLED")]
        public static void Log(object message, LogCategory category = LogCategory.General, UnityEngine.Object context = null)
        {
            string color = GetColorForCategory(category);
            UnityEngine.Debug.Log($"<color={color}>[{category}]</color> {message}", context);
        }

        [Conditional("LOGS_ENABLED")]
        public static void Warning(object message, LogCategory category = LogCategory.General, UnityEngine.Object context = null)
        {
            string color = GetColorForCategory(category);
            UnityEngine.Debug.LogWarning($"<color={color}><b>[{category}]</b></color> {message}", context);
        }

        // no Conditional, because errors better to dump into logs
        public static void Error(object message, LogCategory category = LogCategory.General, UnityEngine.Object context = null)
        {
            UnityEngine.Debug.LogError($"<color=red><b>[{category}] ERROR:</b></color> {message}", context);
        }

        private static string GetColorForCategory(LogCategory category)
        {
            return category switch
            {
                LogCategory.General  => "#ffffff",      // white
                LogCategory.Gameplay => "#00ff00",      // green
                LogCategory.AI       => "#ffad00",      // orange
                LogCategory.UI       => "#ff00ff",      // magenta
                LogCategory.Audio    => "#4eb3ff",      // blue
                _                    => "#ffffff"
            };
        }
    }
}