using System;
using UnityEngine;

namespace FruitNinja
{
    public class TrailModel: IDisposable
    {
        public event Action<bool> OnMouseButtonDown;
        
        private TrailRenderer _trail;
        private Camera _mainCamera;

        private bool _isMouseButtonDown = false;

        public TrailModel(TrailRenderer trail, Camera mainCamera)
        {
            _trail = trail;
            _mainCamera = mainCamera;
        }

        public bool IsMouseButtonDown
        {
            get
            {
                return _isMouseButtonDown;
            }
            set
            {
                _isMouseButtonDown = value;
                OnMouseButtonDown?.Invoke(value);
            }
        }

        public void TrailMover()
        {
            if(!IsMouseButtonDown) return;
            
            _trail.transform.position = new Vector3(_mainCamera.ScreenToWorldPoint(Input.mousePosition).x, 
                                                _mainCamera.ScreenToWorldPoint(Input.mousePosition).y,0); 
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsMouseButtonDown = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsMouseButtonDown = false;
            }
            
            TrailMover();
        }

        public void Dispose()
        {
            OnMouseButtonDown = null;
        }
    }
}