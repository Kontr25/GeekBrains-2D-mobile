using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Weapon
{

    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _bulletRigidbody;
        [SerializeField] private float _shotForce;
        private bool _isBulletFly;
        private List<Vector3> _reflectPoint = new List<Vector3>();
        private Transform _parent;
        private WaitForSeconds _bulletLifetime;
        private Coroutine _shotRoutine;

        private void Awake()
        {
            _parent = transform.parent;
            _bulletLifetime = new WaitForSeconds(1f);
        }

        private void OnEnable()
        {
            _shotRoutine =  StartCoroutine((ShotBullet()));
        }
        
        private void OnDisable()
        {
            if (_shotRoutine != null)
            {
                StopCoroutine(_shotRoutine);
                _shotRoutine = null; 
            }
        }

        private void FixedUpdate()
        {
            if (_isBulletFly)
            {
                _bulletRigidbody.velocity = transform.right * _shotForce;
            }
        }
        
        private IEnumerator FastDisable()
        {
            yield return new WaitForSeconds(.2f);
            gameObject.SetActive(false);
            transform.parent = _parent;
            _bulletRigidbody.velocity = Vector3.zero;
        }

        private IEnumerator ShotBullet()
        {
            _isBulletFly = true;
            transform.rotation = _parent.rotation;
            transform.parent = null;
            yield return _bulletLifetime;
            
            _isBulletFly = false;
            _bulletRigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
            transform.parent = _parent;
        }
    }
}
