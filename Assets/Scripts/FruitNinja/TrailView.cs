using System;
using UnityEngine;

namespace FruitNinja
{
    public class TrailView : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private Camera _mainCamera;


        public TrailRenderer Trail
        {
            get => _trail;
            set => _trail = value;
        }

        public Camera MainCamera
        {
            get => _mainCamera;
            set => _mainCamera = value;
        }

        public void TrailEmitting(bool value)
        {
            switch (value)
            {
                case true:
                    _trail.emitting = true;
                    break;
                case false:
                    _trail.emitting = false;
                    break;
            }
        }
    }
}