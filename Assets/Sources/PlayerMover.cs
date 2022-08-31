using System;
using UnityEngine;

namespace Sources
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _force;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Jump(Vector2 direction)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(new Vector3(direction.x, 0, direction.y).normalized * _force, ForceMode.Impulse);
        }
    }
}
