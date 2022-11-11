using DefaultNamespace.Car;
using DefaultNamespace.Inventory.Configs;
using DefaultNamespace.Inventory.Interface;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Inventory
{
    public class InventoryCell : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameField;
        [SerializeField] private Image _iconImage;

        private ItemConfig _item;
        private Inventory _inventory;
        private CarModel _car;
        
        public void Render(ItemConfig item, Inventory inventory, CarModel car)
        {
            _item = item;
            _inventory = inventory;
            _car = car;
            _nameField.text = item.Name;
            _iconImage.sprite = item.Icon;
        }

        public void GetItem()
        {
            switch (_item.Type)
            {
                case UpgadeType.none:
                    break;
                case UpgadeType.speedup:
                    UpgradeSpeed();
                    break;
                case UpgadeType.weapon:
                    UpgradeWeapon();
                    break;
            }

            _inventory.ItemsList.Remove(_item);
            Destroy(gameObject);
        }

        private void UpgradeWeapon()
        {
            Weapon.Weapon weapon = Instantiate(_inventory.Weaponprefabs, _car.WeaponPoint.position, quaternion.identity);
        }

        private void UpgradeSpeed()
        {
            _car.Speed += _inventory.AccelerationSpeed;
        }
    }
}