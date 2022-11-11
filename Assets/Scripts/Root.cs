using DefaultNamespace.Car;
using UnityEngine;

namespace DefaultNamespace
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private CarView _carView;
        [SerializeField] private Inventory.Inventory _inventory;

        private CarModel _carModel;
        private CarController _carController;

        private void Start()
        {
            _carModel = new CarModel(_carView.CarJoystick, _carView.Background, _carView.Speed, _carView.WeaponPoint);
            _inventory.Car = _carModel;
        }

        private void Update()
        {
            _carModel.Update();
        }
    }
}