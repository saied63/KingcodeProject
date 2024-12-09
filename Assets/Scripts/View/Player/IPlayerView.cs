using UnityEngine;

namespace view
{
    public interface IPlayerView
    {
        void UpdatePosition(Vector3 target, Utility.InputMode inputMode = Utility.InputMode.WASD);
        void MoveViaWASD();
        void MoveViaPointAndClick();
        void MoveViaMovementUI();
    }
}
