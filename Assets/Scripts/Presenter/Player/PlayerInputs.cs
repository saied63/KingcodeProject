using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Zenject;

namespace Presenter
{
    public class PlayerInputs : MonoBehaviour
    {
        private IPlayerPresenter _presenter;
        private PlayerInputActions _inputActions;
        private int _currentInputMode ; // 1 = WASD, 2 = PointAndClick, 3 = MovementUI
        private Vector2 _movementInput;
        [Inject]
        public void Construct(IPlayerPresenter presenter)
        {
            _presenter = presenter;
            _inputActions = new PlayerInputActions();
            _currentInputMode = 1;
        }

        private void OnEnable()
        {
            _inputActions.PlayerMovement.Enable();
            _inputActions.PlayerMovement.WASD.performed += OnWASDPerformed;
            _inputActions.PlayerMovement.WASD.canceled += OnWASDPCanceled;
            _inputActions.PlayerMovement.PointAndClick.performed += OnPointAndClick;
            _inputActions.PlayerMovement.MovementUI.performed += OnMovementUI;
            // Switch input mode based on key press (1, 2, or 3)
            _inputActions.PlayerMovement.SwitchInputMode.performed += OnSwitchInputMode;
        }

        private void OnDisable()
        {
            _inputActions.PlayerMovement.Disable();
        }

        private void OnWASDPerformed(InputAction.CallbackContext context)
        {
            if (_currentInputMode == 1)
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
            if (_currentInputMode == 2)
            {
                if (context.performed)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        _presenter.HandleMoveInput(new Vector2(hit.point.x, hit.point.z) );
                    }
                }      
            }
        }

        private void OnMovementUI(InputAction.CallbackContext context)
        {
            print(context.control.name);
            if (_currentInputMode == 3)
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
                _currentInputMode = 1; // WASD
            }
            else if (control.name == "2")
            {
                _currentInputMode = 2; // Point-and-Click
            }
            else if (control.name == "3")
            {
                _currentInputMode = 3; // UI Movement
            }
            _presenter.SwitchInputMode(_currentInputMode);
        }

    }
}
