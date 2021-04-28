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

        private void Awake() => _cam = Camera.main;

        private void OnEnable() => InputManager.OnTouchHold += Move;

        private void OnDisable() => InputManager.OnTouchHold -= Move;

        private void Move(Vector2 screenPosition)
        {
            if(screenPosition.x >= Screen.width / 2)
                transform.position += Vector3.right * changableValues.moveSpeed * Time.deltaTime;
            else
                transform.position += Vector3.left * changableValues.moveSpeed * Time.deltaTime;

            //FIXME:
            Mathf.Clamp(transform.position.x, _cam.ScreenToWorldPoint(new Vector2(0f, 0f)).x, _cam.ScreenToWorldPoint(new Vector2(Screen.width, 0f)).x);
        }

        private void OnTriggerEnter(Collider other) => GameOver();

        //TODO:
        private void GameOver()
        {

        }

        [System.Serializable]
        public class ChangableValues
        {
            public float moveSpeed;
        }
    }
}
