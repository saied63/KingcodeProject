using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace view
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        private Vector2 _currentMovement;
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private Utility.InputMode _lastInputMode;


        public void UpdatePosition(Vector3 dir , Utility.InputMode inputMode)
        {
            _currentMovement = dir;
            _lastInputMode = inputMode;
        }



    

        private void FixedUpdate()
        {
            // Convert the 2D movement input to 3D movement
            Vector3 movement = new Vector3(_currentMovement.x, 0, _currentMovement.y);
            transform.Translate(movement * movementSpeed*Time.fixedDeltaTime);
        }


        public void MoveViaMovementUI(Vector3 direction)
        {
            throw new System.NotImplementedException();
        }

        public void MoveViaPointAndClick(Vector3 direction)
        {
            throw new System.NotImplementedException();
        }

        public void MoveViaWASD(Vector3 direction)
        {
            //Position += direction;
        }

        public void SetMovementInput(Vector3 direction)
        {
            //Position += direction;
        }
    }
}
