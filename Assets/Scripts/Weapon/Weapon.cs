using System;
using System.Collections;
using Pool;
using UnityEngine;

namespace DefaultNamespace.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private int _pollCapacity;
        [SerializeField] private float _shotDelay;
        
        private ObjectPool<Bullet> _pool;
        private Coroutine _shooterRoutine;
        private WaitForSeconds _delayBetweenShots;

        private void Start()
        {
            _pool = new ObjectPool<Bullet>(_bullet, _pollCapacity, _shotPoint)
            {
                AutoExpand = true
            };
            
            _delayBetweenShots = new WaitForSeconds(_shotDelay);
            
            _shooterRoutine = StartCoroutine(Shot());
        }
        
        private IEnumerator Shot()
        {
            while (true)
            {
                yield return _delayBetweenShots;
                CreateBullet();
            }
        }
        
        private void CreateBullet()
        {
            var bullet = _pool.GetFreeElement();
            bullet.transform.position = _shotPoint.position;
        }
    }
}