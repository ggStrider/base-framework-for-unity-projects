using ggStrider.Shared.Scripts.Runtime.Core.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.Buttons
{
    public abstract class BaseButtonUI : MonoBehaviour
    {
        [SerializeField] protected Button ButtonToBind;

        protected virtual void Awake()
        {
            if (ButtonToBind != null)
            {
                ButtonToBind.onClick.AddListener(OnClick);
            }
            else
            {
                ggDebug.Error($"Button to bind is null! GameObject: {gameObject.name}", LogCategory.UI);
            }
        }

        public void ClearAllBindings()
        {
            if (ButtonToBind != null)
            {
                ButtonToBind.onClick.RemoveAllListeners();
            }
            else
            {
                ggDebug.Error($"Button to bind is null! GameObject: {gameObject.name}", LogCategory.UI);
            }
        }

        protected abstract void OnClick();

#if UNITY_EDITOR
        protected virtual void Reset()
        {
            if (ButtonToBind == null)
            {
                if (TryGetComponent<Button>(out var button))
                {
                    ButtonToBind = button;
                }
            }
        }
#endif
    }
}