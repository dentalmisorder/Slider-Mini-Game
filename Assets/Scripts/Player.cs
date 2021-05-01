using System;
using UnityEngine;
using Slider.Base;

namespace Slider.Gameplay
{  
    public class Player : MonoBehaviour
    {
        public ChangableValues settings;

        public static Action OnGameOver;

        private Camera _cam;
        private Vector3 viewportPoint;

        private void Awake() => _cam = Camera.main;

        private void OnEnable() => InputManager.OnTouchHold += Move;

        private void OnDisable() => InputManager.OnTouchHold -= Move;

        private void Start() => transform.position = _cam.ViewportToWorldPoint(new Vector3(0.5f, settings.playerHeight, _cam.nearClipPlane + 1f));

        private void Move(Vector2 screenPosition)
        {
            viewportPoint = _cam.WorldToViewportPoint(transform.position);

            if(screenPosition.x > Screen.width / 2 && viewportPoint.x + settings.moveBorder < 1f)
                transform.position += Vector3.right * settings.moveSpeed * Time.deltaTime;
            else if(screenPosition.x < Screen.width / 2 && viewportPoint.x - settings.moveBorder > 0)
                transform.position += Vector3.left * settings.moveSpeed * Time.deltaTime; 
        }

        private void OnTriggerEnter(Collider other) => GameOver();

        private void GameOver()
        {
            OnGameOver?.Invoke();

            Time.timeScale = 0.2f;
            DestroyPlayer();
            Debug.Log("<color=yellow>[Player]</color> Its over, Anakin");
        }

        private void DestroyPlayer() => Destroy(this.gameObject);

        [System.Serializable]
        public class ChangableValues
        {
            public float moveSpeed = 4f;
            [Range(0.05f, 0.4f)] public float moveBorder = 0.1f;
            [Range(0.05f, 0.5f)] public float playerHeight = 0.1f;
        }
    }
}
