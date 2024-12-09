using UnityEngine;

namespace view
{
    public interface IPlayerView
    {
        
        void UpdatePosition(Vector3 position , Utility.InputMode inputMode);
        void MoveViaWASD(Vector3 direction);
        void MoveViaPointAndClick(Vector3 direction);
        void MoveViaMovementUI(Vector3 direction);
    }
}
