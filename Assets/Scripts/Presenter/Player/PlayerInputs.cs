using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Presenter
{
    public class PlayerInputs : MonoBehaviour
    {
        private IPlayerPresenter _presenter;
        private PlayerInputActions _inputActions;
        private int _currentInputMode = 0; // 0 = WASD, 1 = PointAndClick, 2 = UI
        private Vector2 _movementInput;
        [Inject]
        public void Construct(IPlayerPresenter presenter)
        {
            _presenter = presenter;
            _inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _inputActions.PlayerMovement.Enable();

            _inputActions.PlayerMovement.WASD.performed += OnWASDPerformed;
            _inputActions.PlayerMovement.WASD.canceled += OnWASDPCanceled;

            _inputActions.PlayerMovement.PointAndClick.performed += OnPointAndClick;
            _inputActions.PlayerMovement.MovementUI.performed += OnUIMove;

            // Switch input mode based on key press (1, 2, or 3)
            _inputActions.PlayerMovement.SwitchInputMode.performed += OnSwitchInputMode;
        }

        private void OnDisable()
        {
            _inputActions.PlayerMovement.Disable();
        }

        private void OnWASDPerformed(InputAction.CallbackContext context)
        {
            print(context.control.name);
            if (_currentInputMode == 0)
            {
                _movementInput = context.ReadValue<Vector2>();
                _presenter.HandleMoveInput(_movementInput);
            }
        }

        private void OnWASDPCanceled(InputAction.CallbackContext context)
        {
            // Reset the movement input when the key is released
            _movementInput = Vector2.zero;
            _presenter.HandleMoveInput(_movementInput);
        }

        private void OnPointAndClick(InputAction.CallbackContext context)
        {
            print(context.control.name);
            if (_currentInputMode == 1)
            {
                _presenter.HandleMoveInput(context.ReadValue<Vector2>());
            }
        }

        private void OnUIMove(InputAction.CallbackContext context)
        {
            print(context.control.name);
            if (_currentInputMode == 2)
            {
                _presenter.HandleMoveInput(context.ReadValue<Vector2>());
            }
        }



        private void OnSwitchInputMode(InputAction.CallbackContext context)
        {
            // Determine which key triggered the action
            var control = context.control;
        
            if (control.name == "1")
            {
                _currentInputMode = 0; // WASD
            }
            else if (control.name == "2")
            {
                _currentInputMode = 1; // Point-and-Click
            }
            else if (control.name == "3")
            {
                _currentInputMode = 2; // UI Movement
            }

            _presenter.SwitchInputMode(_currentInputMode);
        }

    }
}
