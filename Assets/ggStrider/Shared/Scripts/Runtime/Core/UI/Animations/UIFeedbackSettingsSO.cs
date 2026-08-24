using System.Collections.Generic;
using DG.Tweening;
using ggStrider.Shared.Scripts.Runtime.Core.Misc;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.Animations
{
    [CreateAssetMenu(fileName = "New UI Interaction Feedback", menuName = ConstKeys.SO_BRANCH + "UI/Feedback")]
    public class UIFeedbackSettingsSO : ScriptableObject
    {
        [SerializeField] private float _duration = 0.15f;
        [SerializeField] private Ease _ease = Ease.OutQuad;

        [Space]
        [SerializeField] private UIInteractionFeedback.UIAnimationStep[] _onHover;
        [SerializeField] private UIInteractionFeedback.UIAnimationStep[] _onPress;

        public float Duration => _duration;
        public Ease Ease => _ease;
        public IReadOnlyList<UIInteractionFeedback.UIAnimationStep> OnHover => _onHover;
        public IReadOnlyList<UIInteractionFeedback.UIAnimationStep> OnPress => _onPress;
    }
}