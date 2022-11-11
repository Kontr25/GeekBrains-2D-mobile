using UnityEngine;

namespace DefaultNamespace.Car
{
    public class CarView: MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private SpriteRenderer[] _background;
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private Transform _weaponPoint;
        

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public SpriteRenderer[] Background
        {
            get => _background;
            set => _background = value;
        }

        public FloatingJoystick CarJoystick
        {
            get => _joystick;
            set => _joystick = value;
        }

        public Transform WeaponPoint
        {
            get => _weaponPoint;
            set => _weaponPoint = value;
        }
    }
}