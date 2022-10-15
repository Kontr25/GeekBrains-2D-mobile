using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TapMechanics
{
    public class TapModel: IDisposable
    {
        public event Action OnJump;
        
        private Transform _jumpEffectPosition;
        private Camera _mainCamera;
        private Rigidbody2D _rigidbody2D;
        private float _jumpForce;

        public TapModel(Transform jumpEffectPosition, Camera mainCamera, Rigidbody2D rigidbody2D, float jumpForce)
        {
            _jumpEffectPosition = jumpEffectPosition;
            _mainCamera = mainCamera;
            _rigidbody2D = rigidbody2D;
            _jumpForce = jumpForce;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnJump?.Invoke();
                _jumpEffectPosition.position = new Vector3(_mainCamera.ScreenToWorldPoint(Input.mousePosition).x,
                    _mainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0);
                _rigidbody2D.AddForce(_rigidbody2D.transform.up * _jumpForce, ForceMode2D.Impulse);
                _rigidbody2D.angularVelocity = Random.Range(-2, 2);
            }
        }

        public void Dispose()
        {
            OnJump = null;
        }
    }
}