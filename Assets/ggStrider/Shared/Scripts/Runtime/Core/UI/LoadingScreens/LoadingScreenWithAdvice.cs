using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens.Additional;
using ggStrider.Shared.Scripts.Runtime.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens
{
    public class LoadingScreenWithAdvice : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private Image _overlay;

        [Space]
        [SerializeField] private CanvasGroup _parentOfAdvices;
        [SerializeField] private Image _adviceImage;
        [SerializeField] private TextMeshProUGUI _adviceLabel;

        [Space]
        [SerializeField] private float _fadeToOverlayDuration = 3f;
        [SerializeField] private float _fadeToShowAdviceDuration = 2f;

        [Space] 
        [SerializeField] private GameObject _parentOfAllLoadingScreen;

        [Space]
        [SerializeField] private AdvicesForLoadingScreenSO _advices;

        public async UniTask FadeToLoadingScreen()
        {
            try
            {
                _parentOfAllLoadingScreen.SetActive(true);

                RefreshAdvice();

                _overlay.color = Color.clear;
                await _overlay.DOColor(Color.black, _fadeToOverlayDuration)
                    .SetEase(Ease.Linear)
                    .AsyncWaitForCompletion()
                    .AsUniTask()
                    .AttachExternalCancellation(destroyCancellationToken);

                await _parentOfAdvices.DOFade(1, _fadeToShowAdviceDuration)
                    .SetEase(Ease.Linear)
                    .AsyncWaitForCompletion()
                    .AsUniTask()
                    .AttachExternalCancellation(destroyCancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
        }

        public async UniTask UnfadeFromLoadingScreen()
        {
            try
            {
                _overlay.color = Color.black;

                await _parentOfAdvices.DOFade(0, _fadeToShowAdviceDuration)
                    .SetEase(Ease.Linear)
                    .AsyncWaitForCompletion()
                    .AsUniTask()
                    .AttachExternalCancellation(destroyCancellationToken);

                await _overlay.DOColor(Color.clear, _fadeToOverlayDuration)
                    .SetEase(Ease.Linear)
                    .AsyncWaitForCompletion()
                    .AsUniTask()
                    .AttachExternalCancellation(destroyCancellationToken);

                _parentOfAllLoadingScreen.SetActive(false);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void RefreshAdvice()
        {
            if (_advices == null)
            {
                ggDebug.Error("Advices SO is null in loading screen!", LogCategory.UI);
                return;
            }

            var spriteWithSize = _advices.GetRandomSpriteWithSize();
            if (spriteWithSize != null)
            {
                _adviceImage.sprite = spriteWithSize.Sprite;
                _adviceImage.rectTransform.sizeDelta = spriteWithSize.SizeInCanvas;
            }
            else
            {
                ggDebug.Error("Sprite with size is null!");
            }

            var adviceText = _advices.GetRandomAdvice();
            _adviceLabel.text = adviceText;
        }
    }
}