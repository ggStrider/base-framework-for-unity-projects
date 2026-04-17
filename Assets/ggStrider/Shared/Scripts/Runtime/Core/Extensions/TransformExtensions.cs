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
                var p = _t.position;
                p.x = x;
                _t.position = p;
                return this;
            }

            public TransformPositionWorld SetY(float y)
            {
                var p = _t.position;
                p.y = y;
                _t.position = p;
                return this;
            }

            public TransformPositionWorld SetZ(float z)
            {
                var p = _t.position;
                p.z = z;
                _t.position = p;
                return this;
            }

            public TransformPositionWorld AddX(float x)
            {
                var p = _t.position;
                p.x += x;
                _t.position = p;
                return this;
            }

            public TransformPositionWorld AddY(float y)
            {
                var p = _t.position;
                p.y += y;
                _t.position = p;
                return this;
            }

            public TransformPositionWorld AddZ(float z)
            {
                var p = _t.position;
                p.z += z;
                _t.position = p;
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
                var p = _t.localPosition;
                p.x = x;
                _t.localPosition = p;
                return this;
            }

            public TransformPositionLocal SetY(float y)
            {
                var p = _t.localPosition;
                p.y = y;
                _t.localPosition = p;
                return this;
            }

            public TransformPositionLocal SetZ(float z)
            {
                var p = _t.localPosition;
                p.z = z;
                _t.localPosition = p;
                return this;
            }

            public TransformPositionLocal AddX(float x)
            {
                var p = _t.localPosition;
                p.x += x;
                _t.localPosition = p;
                return this;
            }

            public TransformPositionLocal AddY(float y)
            {
                var p = _t.localPosition;
                p.y += y;
                _t.localPosition = p;
                return this;
            }

            public TransformPositionLocal AddZ(float z)
            {
                var p = _t.localPosition;
                p.z += z;
                _t.localPosition = p;
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
                var e = _t.eulerAngles;
                e.x = x;
                _t.eulerAngles = e;
                return this;
            }

            public TransformRotationWorld SetY(float y)
            {
                var e = _t.eulerAngles;
                e.y = y;
                _t.eulerAngles = e;
                return this;
            }

            public TransformRotationWorld SetZ(float z)
            {
                var e = _t.eulerAngles;
                e.z = z;
                _t.eulerAngles = e;
                return this;
            }

            public TransformRotationWorld AddX(float x)
            {
                var e = _t.eulerAngles;
                e.x += x;
                _t.eulerAngles = e;
                return this;
            }

            public TransformRotationWorld AddY(float y)
            {
                var e = _t.eulerAngles;
                e.y += y;
                _t.eulerAngles = e;
                return this;
            }

            public TransformRotationWorld AddZ(float z)
            {
                var e = _t.eulerAngles;
                e.z += z;
                _t.eulerAngles = e;
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
                var e = _t.localEulerAngles;
                e.x = x;
                _t.localEulerAngles = e;
                return this;
            }

            public TransformRotationLocal SetY(float y)
            {
                var e = _t.localEulerAngles;
                e.y = y;
                _t.localEulerAngles = e;
                return this;
            }

            public TransformRotationLocal SetZ(float z)
            {
                var e = _t.localEulerAngles;
                e.z = z;
                _t.localEulerAngles = e;
                return this;
            }

            public TransformRotationLocal AddX(float x)
            {
                var e = _t.localEulerAngles;
                e.x += x;
                _t.localEulerAngles = e;
                return this;
            }

            public TransformRotationLocal AddY(float y)
            {
                var e = _t.localEulerAngles;
                e.y += y;
                _t.localEulerAngles = e;
                return this;
            }

            public TransformRotationLocal AddZ(float z)
            {
                var e = _t.localEulerAngles;
                e.z += z;
                _t.localEulerAngles = e;
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
                var s = _t.localScale;
                s.x = x;
                _t.localScale = s;
                return this;
            }

            public TransformLocalScale SetY(float y)
            {
                var s = _t.localScale;
                s.y = y;
                _t.localScale = s;
                return this;
            }

            public TransformLocalScale SetZ(float z)
            {
                var s = _t.localScale;
                s.z = z;
                _t.localScale = s;
                return this;
            }

            public TransformLocalScale AddX(float x)
            {
                var s = _t.localScale;
                s.x += x;
                _t.localScale = s;
                return this;
            }

            public TransformLocalScale AddY(float y)
            {
                var s = _t.localScale;
                s.y += y;
                _t.localScale = s;
                return this;
            }

            public TransformLocalScale AddZ(float z)
            {
                var s = _t.localScale;
                s.z += z;
                _t.localScale = s;
                return this;
            }
        }

        #endregion
    }
}