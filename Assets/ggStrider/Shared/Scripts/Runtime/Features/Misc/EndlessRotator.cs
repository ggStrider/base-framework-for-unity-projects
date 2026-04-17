using DG.Tweening;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Features.Misc
{
    public class EndlessRotator : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private bool _ignoreTimeScale = true;
        
        [Space]
        [SerializeField] private Vector3 _rotateTo = new(0, 0, 360);
        [SerializeField] private float _timeToRotate = 2f;
        [SerializeField] private Ease _ease = Ease.Linear;

        private void OnEnable()
        {
            _target.DORotate(_rotateTo, _timeToRotate)
                .SetEase(_ease)
                .SetLoops(-1, LoopType.Incremental)
                .SetUpdate(_ignoreTimeScale);
        }

        private void OnDisable()
        {
            _target?.DOKill();
        }

#if UNITY_EDITOR
        private void Reset()
        {
            if (_target == null)
            {
                _target = transform;
            }
        }
#endif
    }
}