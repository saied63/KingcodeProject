using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Presenter
{
    public class PlayerPresenter : IPlayerPresenter
    {
        private readonly model.IPlayerModel _model;
        private readonly view.IPlayerView _view;
        private readonly view.ICameraView _cameraView;

     
        private Utility.InputMode _currentMode = Utility.InputMode.WASD;

        public PlayerPresenter(model.IPlayerModel model, view.IPlayerView view, view.ICameraView cameraView)
        {
            _model = model;
            _view = view;
            _cameraView = cameraView;
        }

        public void HandleMoveInput(Vector2 input)
        {
            Vector3 direction = Vector3.zero;

            switch (_currentMode)
            {
                case Utility.InputMode.WASD:
                    direction = new Vector3(input.x, 0, input.y);
                    break;
                case Utility.InputMode.PointAndClick:
                    // Raycast to find the click position
                    Ray ray = Camera.main.ScreenPointToRay(input);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        direction = hit.point - _model.Position;
                    }
                    break;

                case Utility.InputMode.MovementUI:
                    direction = new Vector3(input.x, 0, 0); // Assuming horizontal movement (left/right)
                    break;
            }
            _model.UpdatePosition(direction);
            _view.UpdatePosition(_model.Position, _currentMode);
            _cameraView.FollowPlayer(_model.Position);
        }



        public void SwitchInputMode(int mode)
        {
            _currentMode = (Utility.InputMode)mode;
        }

    }
}
