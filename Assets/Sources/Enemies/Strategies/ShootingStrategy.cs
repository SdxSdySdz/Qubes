using UnityEngine;

namespace Sources.Enemies.Strategies
{
    public class ShootingStrategy : MonoBehaviour
    {
        [SerializeField] private Shooter _shooter;
        [SerializeField] private float _timeBetweenShoots;

        private float _time;
        private bool _activated;

        private void Awake()
        {
            _time = 0;
        }
        
        private void Update()
        {
            if (_time > _timeBetweenShoots)
            {
                if (_activated)
                    _shooter.Shoot();
                
                _time = 0;
            }
            _time += Time.deltaTime;
        }

        public void Activate()
        {
            _activated = true;
        }

        public void Deactivate()
        {
            _activated = false;
        }
    }
}