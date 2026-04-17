using UnityEngine;

namespace ggStrider.TwoDimensional.Scripts.Runtime.Features.Player.TopDown
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerTopDownMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}