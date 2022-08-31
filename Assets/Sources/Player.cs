using Sources.Enemies;
using Sources.Extensions;
using UnityEngine;

namespace Sources
{
    [RequireComponent(typeof(PlayerMover))]
    public class Player : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.CollidedWith(out Shooter enemy))
            {
                enemy.Die();
            }
        }

        public void TakeDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}