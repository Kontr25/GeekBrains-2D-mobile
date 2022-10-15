namespace TapMechanics
{
    public class TapController
    {
        private TapModel _tapModel;
        private TapView _tapView;

        public TapController(TapModel tapModel, TapView tapView)
        {
            _tapModel = tapModel;
            _tapView = tapView;

            _tapModel.OnJump += _tapView.Blink;
        }
    }
}