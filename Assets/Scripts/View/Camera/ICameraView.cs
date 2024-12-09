using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace view
{
    public interface ICameraView
    {
        void FollowPlayer(Vector3 playerPosition);
    }
}
