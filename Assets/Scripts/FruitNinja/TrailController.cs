namespace FruitNinja
{
    public class TrailController
    {
        private TrailModel _trailModel;
        private TrailView _trailView;

        public TrailController(TrailModel trailModel, TrailView trailView)
        {
            _trailModel = trailModel;
            _trailView = trailView;

            _trailModel.OnMouseButtonDown += _trailView.TrailEmitting;
        }
    }
}