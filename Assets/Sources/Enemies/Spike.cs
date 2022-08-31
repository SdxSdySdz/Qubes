using Sources.Extensions;
using UnityEngine;

namespace Sources.Enemies
{
    public class Spike : Enemy
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.CollidedWith(out Player player))
                player.TakeDamage();
        }
    }
}