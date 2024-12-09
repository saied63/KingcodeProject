using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace view
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        public void UpdatePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
