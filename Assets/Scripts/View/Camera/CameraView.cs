using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.StandaloneInputModule;

namespace view
{
    public class CameraView : MonoBehaviour, ICameraView
    {
        public Transform playerTransform;
        public Vector3 offset;

        private void LateUpdate()
        {
            FollowPlayer(playerTransform.position);
        }

        public void FollowPlayer(Vector3 playerPosition)
        {
            Vector3 desiredPosition = playerPosition + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
        }

 
    }
}
