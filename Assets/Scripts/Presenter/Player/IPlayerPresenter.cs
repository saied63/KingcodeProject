using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presenter
{
    public interface IPlayerPresenter
    {
        void HandleMoveInput(Vector2 input);
        void SwitchInputMode(int mode);
    }

}