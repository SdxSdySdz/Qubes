using System;
using UnityEngine;
using UnityEngine.Events;

namespace Sources.Enemies.Strategies
{
    public class HuntingStrategy : MonoBehaviour
    {
        [SerializeField] private Shooter _shooter;
        [Min(0)] 
        [SerializeField] private float _detectionDistance;
        
        private bool _isTargetInSight;

        private void Update()
        {
            float distanceToTarget = _shooter.DistanceToTarget;

            if (_isTargetInSight)
            {
                if (distanceToTarget > _detectionDistance)
                    OnTargetLost();
            }
            else
            {
                if (distanceToTarget <= _detectionDistance)
                    OnTargetDetected();
            }
        }
        
        private void OnTargetDetected()
        {
            _isTargetInSight = true;
            _shooter.FollowTarget();
        }

        private void OnTargetLost()
        {
            _isTargetInSight = false;
            _shooter.UnfollowTarget();
        }
    }
}