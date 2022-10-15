using UnityEngine;

namespace TapMechanics
{
    public class TapView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _tapEffect;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private float _jumpForce;

        public ParticleSystem TapEffect
        {
            get => _tapEffect;
            set => _tapEffect = value;
        }

        public Camera MainCamera
        {
            get => _mainCamera;
            set => _mainCamera = value;
        }

        public Rigidbody2D Rigidbody2D
        {
            get => _rigidbody2D;
            set => _rigidbody2D = value;
        }

        public float JumpForce
        {
            get => _jumpForce;
            set => _jumpForce = value;
        }

        public void Blink()
        {
            TapEffect.Play();
        }
    }
}