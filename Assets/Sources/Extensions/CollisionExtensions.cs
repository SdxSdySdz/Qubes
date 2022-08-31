using UnityEngine;

namespace Sources.Extensions
{
    public static class CollisionExtensions
    {
        public static bool CollidedWith<T>(this Collision collision)
            where T : MonoBehaviour
        {
            return collision.CollidedWith(out T _);
        }

        public static bool CollidedWith<T>(this Collision collision, out T obstruction)
            where T : MonoBehaviour
        {
            return collision.gameObject.TryGetComponent(out obstruction);
        }
    }
}