using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider.Base;

namespace Slider.Gameplay
{  
    public class Player : MonoBehaviour
    {
        public ChangableValues settings;

        private Camera _cam;
        private Vector3 viewportPoint;

        private void Awake() => _cam = Camera.main;

        private void OnEnable() => InputManager.OnTouchHold += Move;

        private void OnDisable() => InputManager.OnTouchHold -= Move;

        private void Move(Vector2 screenPosition)
        {
            viewportPoint = _cam.WorldToViewportPoint(transform.position);

            if(screenPosition.x > Screen.width / 2 && viewportPoint.x + settings.moveBorder < 1f)
                transform.position += Vector3.right * settings.moveSpeed * Time.deltaTime;
            else if(screenPosition.x < Screen.width / 2 && viewportPoint.x - settings.moveBorder > 0)
                transform.position += Vector3.left * settings.moveSpeed * Time.deltaTime; 
        }

        private void OnTriggerEnter(Collider other) => GameOver();

        //TODO: Restart Menu
        private void GameOver()
        {
            Destroy(this.gameObject);
            Debug.Log("<color=yellow>[Player]</color> Its over, Anakin");
        }

        [System.Serializable]
        public class ChangableValues
        {
            public float moveSpeed = 4f;
            [Range(0.05f, 0.4f)] public float moveBorder = 0.1f;
        }
    }
}
