using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider.Base;

namespace Slider.Gameplay
{  
    public class Player : MonoBehaviour
    {
        public ChangableValues changableValues;

        private Camera _cam;
        private Vector3 viewportPoint;

        private void Awake() => _cam = Camera.main;

        private void OnEnable() => InputManager.OnTouchHold += Move;

        private void OnDisable() => InputManager.OnTouchHold -= Move;

        private void Move(Vector2 screenPosition)
        {
            Vector3 viewportPoint = _cam.WorldToViewportPoint(transform.position);

            Debug.Log($"Viewport.x {viewportPoint.x}");

            if(screenPosition.x > Screen.width / 2 && viewportPoint.x < 1f)
                transform.position += Vector3.right * changableValues.moveSpeed * Time.deltaTime;
            else if(screenPosition.x < Screen.width / 2 && viewportPoint.x > 0)
                transform.position += Vector3.left * changableValues.moveSpeed * Time.deltaTime; 
        }

        private void OnTriggerEnter(Collider other) => GameOver();

        //TODO:
        private void GameOver()
        {
            Debug.Log("<color=yellow>[Player]</color> Its over, Anakin");
        }

        [System.Serializable]
        public class ChangableValues
        {
            public float moveSpeed;
        }
    }
}
