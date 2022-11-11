using System;
using UnityEngine;

namespace DefaultNamespace.Car
{
    public class CarModel: IDisposable
    {
        private FloatingJoystick _joystick;
        private SpriteRenderer[] _background;
        private float _border = 17.5f;
        private float _speed;
        private Transform _weaponPoint;

        public CarModel(FloatingJoystick joystick, SpriteRenderer[] background, float speed, Transform weaponPoint)
        {
            _joystick = joystick;
            _background = background;
            _speed = speed;
            _weaponPoint = weaponPoint;
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public Transform WeaponPoint => _weaponPoint;

        public void Update()
        {
            if (_joystick.Horizontal > 0 || _joystick.Horizontal < 0)
            {
                for (int i = 0; i < _background.Length; i++)
                {
                    if(i < _background.Length -1) Move(_joystick.Horizontal, _background[i].transform, _background[i + 1].transform);
                    else if(i == _background.Length - 1) Move(_joystick.Horizontal, _background[i].transform, _background[0].transform);
                }
            }
        }
            
        private void Move(float value, Transform mainSprite, Transform neighboringSprite)
        {
            mainSprite.position += -Vector3.right * value * _speed;
            Vector3 position = mainSprite.position;
            if (position.x <= -_border)
                mainSprite.position = new Vector3(neighboringSprite.position.x + _border, position.y, position.z);
            else if (mainSprite.position.x >= _border)
                mainSprite.position = new Vector3(neighboringSprite.position.x - _border, position.y, position.z);
        }

        
        public void Dispose()
        {
            
        }
    }
}