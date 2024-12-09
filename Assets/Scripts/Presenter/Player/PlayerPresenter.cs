using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Windows;

namespace Presenter
{
    public class PlayerPresenter : IPlayerPresenter
    {
        private readonly model.IPlayerModel _model;
        private readonly view.IPlayerView _view;
        private readonly view.ICameraView _cameraView;
        private Utility.InputMode _currentMode = Utility.InputMode.WASD;// default mode

        public PlayerPresenter(model.IPlayerModel model, view.IPlayerView view, view.ICameraView cameraView)
        {
            _model = model;
            _view = view;
            _cameraView = cameraView;
        }

        /// <summary>
        /// set player position and rotation(for joystick) in model and view
        /// set camera target to current position of player
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputMode"></param>
        public void HandleMoveInput(Vector2 input )
        {
            Vector3 direction = Vector3.zero;

            Debug.LogWarning(_currentMode);

            switch (_currentMode)
            {
                case Utility.InputMode.WASD:
                    direction = new Vector3(input.x, 0, input.y);
                    break;
                case Utility.InputMode.PointAndClick:
                    //GetRaycasthitPoint(input,ref direction);  
                    direction = new Vector3(input.x, 0, input.y);
                    Debug.Log("hit point : "+direction);
                    break;
                case Utility.InputMode.MovementUI:
                    direction = new Vector3(input.x, 0, 0); // Assuming horizontal movement (left/right)
                    break;
            }

            if(_currentMode == Utility.InputMode.None)
                direction = Vector3.zero;

            _model.UpdatePosition(direction);
            _view.UpdatePosition(_model.Position, _currentMode);
            _cameraView.FollowPlayer(_model.Position);
        }

        /// <summary>
        /// get raycast point from screen to plane and set targetPosition to
        /// the direction local variable of HandleMoveInput method
        /// </summary>
        /// <param name="input"></param>
        /// <param name="direction"></param>
        private void GetRaycasthitPoint(Vector2 input , ref Vector3 direction) {
            Ray ray = Camera.main.ScreenPointToRay(input);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                direction = hit.point - _model.Position;
            }
        }

        public void SwitchInputMode(int mode)
        {
            _currentMode = (Utility.InputMode)mode;
        }

    }
}
