using System.Collections.Generic;
using DefaultNamespace.Car;
using DefaultNamespace.Inventory.Configs;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ItemConfig> _items;
        [SerializeField] private InventoryCell _inventoryCellTemplate;
        [SerializeField] private Transform _container;
        [SerializeField] private Weapon.Weapon _weaponprefabs;
        [SerializeField] private float _accelerationSpeed;

        private CarModel _car;
        private bool _isOpen = false;
        private Vector3 _defaultPosition;

        public List<ItemConfig> ItemsList
        {
            get => _items;
            set => _items = value;
        }

        public Weapon.Weapon Weaponprefabs => _weaponprefabs;

        public float AccelerationSpeed => _accelerationSpeed;

        public CarModel Car
        {
            get => _car;
            set => _car = value;
        }

        public void AddItem(ItemConfig item)
        {
            _items.Add(item);
            Render(_items);
        }

        private void Start()
        {
            _defaultPosition = transform.position;
        }

        private void Render(List<ItemConfig> items)
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
            items.ForEach(item =>
            {
                var cell = Instantiate(_inventoryCellTemplate, _container);
                cell.Render(item, this, _car);
            });
        }

        public void OpenClose()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                transform.DOMoveX(0, .5f);
            }
            else
            {
                _isOpen = false;
                transform.DOMoveX(_defaultPosition.x, .5f);
            }
        }
    }
}