using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace view
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Vector3 _currentDirection;
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private Utility.InputMode _lastInputMode;
  
        public void UpdatePosition(Vector3 target , Utility.InputMode inputMode = Utility.InputMode.WASD
            )
        {
            _currentDirection = target;
            _lastInputMode = inputMode;
        }

        /// <summary>
        /// handle three kind of movement according player input choose
        /// </summary>
        void Update()
        {         
            if(_lastInputMode == Utility.InputMode.WASD)
            {
                MoveViaWASD();
            }
            else if (_lastInputMode == Utility.InputMode.PointAndClick)
            {
                MoveViaPointAndClick();
            }
            else if (_lastInputMode == Utility.InputMode.MovementUI)
            {
                MoveViaMovementUI();
            }
            
        }

        /// <summary>
        /// move with keyboard
        /// </summary>
        public void MoveViaWASD()
        {
            if (_currentDirection == Vector3.zero)
                return;
            transform.position += _currentDirection * Time.deltaTime * _movementSpeed;
        }


        /// <summary>
        /// move with click
        /// </summary>
        /// <param name="direction"></param>
        public void MoveViaPointAndClick()
        {
            //Vector3 direction = (_currentDirection - transform.position).normalized;
            if (_currentDirection == Vector3.zero)
                return;
            if (Vector3.Distance(transform.position, _currentDirection) < 0.5f)
            {
                //_lastInputMode = Utility.InputMode.None;
                return;
            }
            //transform.position += _currentDirection * Time.deltaTime * _movementSpeed / 5f;
            transform.position = Vector3.MoveTowards(transform.position, _currentDirection, Time.deltaTime * _movementSpeed );
        }

        /// <summary>
        /// move with joystick
        /// </summary>
        public void MoveViaMovementUI()
        {
            
        }


    }
}
