using System.Collections;
using UnityEngine;

namespace Sources.Jumping
{
    public class Shockwave : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer.enabled = false;
        }

        public void Explode(Vector3 explosionNormal)
        {
            _renderer.enabled = true;
            transform.up = explosionNormal.normalized;
            StartCoroutine(ProvideExplosion());
        }
        
        private IEnumerator ProvideExplosion()
        {
            float timeElapsed = 0f;

            var waitForEndOfFrame = new WaitForEndOfFrame();

            float duration = 1f / _renderer.material.GetFloat("_Speed");
            while (timeElapsed <= duration)
            {
                _renderer.material.SetFloat("_Progress", timeElapsed);
                timeElapsed += Time.deltaTime;
                yield return waitForEndOfFrame;
            }
            
            Destroy(gameObject);
        }
    }
}
