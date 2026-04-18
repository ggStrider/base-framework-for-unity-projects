using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens
{
    public class LoadingScreenWithFading : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private float _fadeDuration = 3f;
        [SerializeField] private float _unFadeDuration = 3f;

        [Space]
        [SerializeField] private Image _blackScreen;

        public async UniTask FadeToLoadingScreen()
        {
            try
            {
                _blackScreen.color = Color.clear;
                await FadeTo(targetColor: Color.black, fadeTime: _fadeDuration);
            }
            catch (OperationCanceledException)
            {
            }
        }

        public async UniTask UnfadeFromLoadingScreen()
        {
            try
            {    _blackScreen.color = Color.black;
                await FadeTo(targetColor: Color.clear, fadeTime: _unFadeDuration);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask FadeTo(Color targetColor, float fadeTime)
        {
            try
            {
                await _blackScreen.DOColor(targetColor, fadeTime)
                    .SetEase(Ease.Linear)
                    .AsyncWaitForCompletion()
                    .AsUniTask()
                    .AttachExternalCancellation(destroyCancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}