using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class TransformExtensions
    {
        public static TransformPosition Position(this Transform transform)
            => new TransformPosition(transform);

        public static TransformRotation Rotation(this Transform transform)
            => new TransformRotation(transform);

        public static TransformLocalScale LocalScale(this Transform transform)
            => new TransformLocalScale(transform);

        #region Position

        public readonly struct TransformPosition
        {
            private readonly Transform _t;

            public TransformPosition(Transform t) => _t = t;

            public TransformPositionWorld World => new TransformPositionWorld(_t);
            public TransformPositionLocal Local => new TransformPositionLocal(_t);
        }

        #region World Position

        public readonly struct TransformPositionWorld
        {
            private readonly Transform _t;

            public TransformPositionWorld(Transform t) => _t = t;

            public TransformPositionWorld SetX(float x)
            {
                _t.position = _t.position.WithX(x);
                return this;
            }

            public TransformPositionWorld SetY(float y)
            {
                _t.position = _t.position.WithY(y);
                return this;
            }

            public TransformPositionWorld SetZ(float z)
            {
                _t.position = _t.position.WithZ(z);
                return this;
            }

            public TransformPositionWorld AddX(float x)
            {
                _t.position = _t.position.AddX(x);
                return this;
            }

            public TransformPositionWorld AddY(float y)
            {
                _t.position = _t.position.AddY(y);
                return this;
            }

            public TransformPositionWorld AddZ(float z)
            {
                _t.position = _t.position.AddZ(z);
                return this;
            }
        }

        #endregion

        #region Local Position

        public readonly struct TransformPositionLocal
        {
            private readonly Transform _t;

            public TransformPositionLocal(Transform t) => _t = t;

            public TransformPositionLocal SetX(float x)
            {
                _t.localPosition = _t.localPosition.WithX(x);
                return this;
            }

            public TransformPositionLocal SetY(float y)
            {
                _t.localPosition = _t.localPosition.WithY(y);
                return this;
            }

            public TransformPositionLocal SetZ(float z)
            {
                _t.localPosition = _t.localPosition.WithZ(z);
                return this;
            }

            public TransformPositionLocal AddX(float x)
            {
                _t.localPosition = _t.localPosition.AddX(x);
                return this;
            }

            public TransformPositionLocal AddY(float y)
            {
                _t.localPosition = _t.localPosition.AddY(y);
                return this;
            }

            public TransformPositionLocal AddZ(float z)
            {
                _t.localPosition = _t.localPosition.AddZ(z);
                return this;
            }
        }

        #endregion

        #endregion

        #region Rotation

        public readonly struct TransformRotation
        {
            private readonly Transform _t;

            public TransformRotation(Transform t) => _t = t;

            public TransformRotationWorld World => new TransformRotationWorld(_t);
            public TransformRotationLocal Local => new TransformRotationLocal(_t);
        }

        #region World Rotation

        public readonly struct TransformRotationWorld
        {
            private readonly Transform _t;

            public TransformRotationWorld(Transform t) => _t = t;

            public TransformRotationWorld SetX(float x)
            {
                _t.eulerAngles = _t.eulerAngles.WithX(x);
                return this;
            }

            public TransformRotationWorld SetY(float y)
            {
                _t.eulerAngles = _t.eulerAngles.WithY(y);
                return this;
            }

            public TransformRotationWorld SetZ(float z)
            {
                _t.eulerAngles = _t.eulerAngles.WithZ(z);
                return this;
            }

            public TransformRotationWorld AddX(float x)
            {
                _t.eulerAngles = _t.eulerAngles.AddX(x);
                return this;
            }

            public TransformRotationWorld AddY(float y)
            {
                _t.eulerAngles = _t.eulerAngles.AddY(y);
                return this;
            }

            public TransformRotationWorld AddZ(float z)
            {
                _t.eulerAngles = _t.eulerAngles.AddZ(z);
                return this;
            }
        }

        #endregion

        #region Local Rotation

        public readonly struct TransformRotationLocal
        {
            private readonly Transform _t;

            public TransformRotationLocal(Transform t) => _t = t;

            public TransformRotationLocal SetX(float x)
            {
                _t.localEulerAngles = _t.localEulerAngles.WithX(x);
                return this;
            }

            public TransformRotationLocal SetY(float y)
            {
                _t.localEulerAngles = _t.localEulerAngles.WithY(y);
                return this;
            }

            public TransformRotationLocal SetZ(float z)
            {
                _t.localEulerAngles = _t.localEulerAngles.WithZ(z);
                return this;
            }

            public TransformRotationLocal AddX(float x)
            {
                _t.localEulerAngles = _t.localEulerAngles.AddX(x);
                return this;
            }

            public TransformRotationLocal AddY(float y)
            {
                _t.localEulerAngles = _t.localEulerAngles.AddY(y);
                return this;
            }

            public TransformRotationLocal AddZ(float z)
            {
                _t.localEulerAngles = _t.localEulerAngles.AddY(z);
                return this;
            }
        }

        #endregion

        #endregion

        #region Scale

        public readonly struct TransformLocalScale
        {
            private readonly Transform _t;

            public TransformLocalScale(Transform t) => _t = t;

            public TransformLocalScale SetX(float x)
            {
                _t.localScale = _t.localScale.WithX(x);
                return this;
            }

            public TransformLocalScale SetY(float y)
            {
                _t.localScale = _t.localScale.WithY(y);
                return this;
            }

            public TransformLocalScale SetZ(float z)
            {
                _t.localScale = _t.localScale.WithZ(z);
                return this;
            }

            public TransformLocalScale AddX(float x)
            {
                _t.localScale = _t.localScale.AddX(x);
                return this;
            }

            public TransformLocalScale AddY(float y)
            {
                _t.localScale = _t.localScale.AddY(y);
                return this;
            }

            public TransformLocalScale AddZ(float z)
            {
                _t.localScale = _t.localScale.AddZ(z);
                return this;
            }
        }

        #endregion
    }
}