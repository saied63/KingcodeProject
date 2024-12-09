using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace model
{
    public class PlayerModel : IPlayerModel
    {      
        public Vector3 Position { get; set; }
        public void UpdatePosition(Vector3 dir)
        {
            Position = dir;
        }
    }
}

