using System;
using DefaultNamespace.Car;
using DefaultNamespace.Inventory.Configs;
using UnityEngine;

namespace DefaultNamespace.Inventory.Items
{
    public class UpgradeItem: MonoBehaviour
    {
        [SerializeField] private ItemConfig _config;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer.sprite = _config.Icon;
        }

        public ItemConfig Config => _config;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out CarView car))
            {
                GetUpgrade(car);
                Destroy(gameObject);
            }
        }

        private void GetUpgrade(CarView component)
        {
            _inventory.AddItem(_config);
        }
    }
}