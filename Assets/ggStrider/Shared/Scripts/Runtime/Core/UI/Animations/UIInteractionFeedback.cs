using System;
using System.Collections.Generic;
using DG.Tweening;
using SaintsField.Playa;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.Animations
{
    /// <summary>Plays scale/rotation tweens on hover and press, from manual data or a shared ScriptableObject.</summary>
    public class UIInteractionFeedback : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public enum AnimationKind
        {
            None,
            AddScale,
            AddRotation
        }

        private enum SettingsSource
        {
            Manually,
            FromScriptable
        }

        [SerializeField] private SettingsSource _settingsSource;

        [Space] [ShowIf(nameof(_settingsSource), SettingsSource.FromScriptable)]
        [SerializeField] private UIFeedbackSettingsSO _settings;

        [ShowIf(nameof(_settingsSource), SettingsSource.FromScriptable)]
        [SerializeField] private Vector3 _scaleOffset;
        [ShowIf(nameof(_settingsSource), SettingsSource.FromScriptable)]
        [SerializeField] private Vector3 _rotationOffset;

        [Space] [ShowIf(nameof(_settingsSource), SettingsSource.Manually)]
        [SerializeField] private float _duration = 0.15f;
        [ShowIf(nameof(_settingsSource), SettingsSource.Manually)]
        [SerializeField] private Ease _ease = Ease.OutQuad;

        [ShowIf(nameof(_settingsSource), SettingsSource.Manually)]
        [SerializeField] private UIAnimationStep[] _hoverAnimations;

        [ShowIf(nameof(_settingsSource), SettingsSource.Manually)]
        [SerializeField] private UIAnimationStep[] _pressAnimations;

        private Vector3 _initialLocalScale;
        private Vector3 _initialLocalEuler;

        private bool _isPointerOver;
        private bool _isPointerDown;
        private bool _isReverted;

        [Serializable]
        public class UIAnimationStep
        {
            [field: SerializeField] public AnimationKind Kind { get; private set; }

            [field: ShowIf(nameof(Kind), AnimationKind.AddScale)]
            [field: SerializeField] public Vector3 ScaleDelta { get; private set; }

            [field: ShowIf(nameof(Kind), AnimationKind.AddRotation)]
            [field: SerializeField] public Vector3 RotationDelta { get; private set; }
        }

        private void Awake()
        {
            _initialLocalScale = transform.localScale;
            _initialLocalEuler = transform.localEulerAngles;
        }

        private void OnDisable()
        {
            transform.DOKill();
            _isPointerOver = false;
            _isPointerDown = false;
            _isReverted = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isPointerOver = true;
            PlayAnimations(GetAnimations(isHover: true));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isPointerOver = false;
            _isPointerDown = false;
            RevertToInitial();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPointerDown = true;
            PlayAnimations(GetAnimations(isHover: false));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPointerDown = false;

            if (_isPointerOver)
                PlayAnimations(GetAnimations(isHover: true));
            else
                RevertToInitial();
        }

        private IReadOnlyList<UIAnimationStep> GetAnimations(bool isHover)
        {
            if (_settingsSource == SettingsSource.FromScriptable)
                return isHover ? _settings.OnHover : _settings.OnPress;

            return isHover ? _hoverAnimations : _pressAnimations;
        }

        private float GetDuration()
        {
            return _settingsSource == SettingsSource.FromScriptable ? _settings.Duration : _duration;
        }

        private Ease GetEase()
        {
            return _settingsSource == SettingsSource.FromScriptable ? _settings.Ease : _ease;
        }

        private void PlayAnimations(IReadOnlyList<UIAnimationStep> steps)
        {
            transform.DOKill();
            _isReverted = false;

            bool useOffset = _settingsSource == SettingsSource.FromScriptable;
            Vector3 scaleOffset = useOffset ? _scaleOffset : Vector3.zero;
            Vector3 rotationOffset = useOffset ? _rotationOffset : Vector3.zero;
            float duration = GetDuration();
            Ease ease = GetEase();

            foreach (UIAnimationStep step in steps)
            {
                switch (step.Kind)
                {
                    case AnimationKind.AddScale:
                        transform.DOScale(_initialLocalScale + step.ScaleDelta + scaleOffset, duration)
                            .SetEase(ease);
                        break;
                    case AnimationKind.AddRotation:
                        transform.DOLocalRotate(_initialLocalEuler + step.RotationDelta + rotationOffset, duration)
                            .SetEase(ease);
                        break;
                }
            }
        }

        private void RevertToInitial()
        {
            if (_isReverted)
                return;

            _isReverted = true;

            float duration = GetDuration();
            Ease ease = GetEase();

            transform.DOKill();
            transform.DOScale(_initialLocalScale, duration).SetEase(ease);
            transform.DOLocalRotate(_initialLocalEuler, duration).SetEase(ease);
        }
    }
}