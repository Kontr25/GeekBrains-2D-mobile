namespace DefaultNamespace.Car
{
    public class CarController
    {
        private CarModel _carModel;
        private CarView _carView;

        public CarController(CarModel carModel, CarView carView)
        {
            _carModel = carModel;
            _carView = carView;
        }
    }
}