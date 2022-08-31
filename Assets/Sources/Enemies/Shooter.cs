using System;
using System.Collections;
using DG.Tweening;
using Sources.Enemies.Strategies;
using UnityEngine;

namespace Sources.Enemies
{
    [RequireComponent(typeof(ShootingStrategy))]
    public class Shooter : Enemy
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private DeathEffect _deathEffect;

        private Player _target;
        private ShootingStrategy _shootingStrategy;
        private HuntingStrategy _huntingStrategy;
        
        public float DistanceToTarget => Vector3.Distance(
            transform.position, 
            _target.transform.position
        );

        private void Awake()
        {
            _target = FindObjectOfType<Player>();
            _shootingStrategy = GetComponent<ShootingStrategy>();
            _huntingStrategy = GetComponent<HuntingStrategy>();
        }
        
        public void Shoot()
        {
            Vector3 originScale = transform.localScale;
            Vector3 targetScale = transform.localScale * 2;

            Sequence tweens = DOTween.Sequence();
            tweens.Append(transform.DOScale(targetScale, 1));
            tweens.Append(transform.DOScale(originScale, 1));

            tweens.OnComplete(Fire);

            tweens.Play();
        }

        private void Fire()
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
        
        public void Die()
        {
            Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        public void FollowTarget()
        {
            throw new NotImplementedException();
        }

        public void UnfollowTarget()
        {
            throw new NotImplementedException();
        }
    }
}