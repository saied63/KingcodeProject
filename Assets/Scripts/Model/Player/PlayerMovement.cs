using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace model
{
    public class PlayerModel : IPlayerModel
    {
        public Vector3 Position { get; set; }

        public void Move(Vector3 direction)
        {
            Position += direction;
        }

    }
}

