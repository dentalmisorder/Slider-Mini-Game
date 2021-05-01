using System;
using UnityEngine.UI;
using UnityEngine;
using Slider.Gameplay;

namespace Slider.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        private Canvas _canvas;

        private void Awake() => _canvas = GetComponentInChildren<Canvas>(true);

        private void OnEnable() => Player.OnGameOver += EnableUI;

        public void Quit() => Application.Quit();

        public void EnableUI() 
        {
            scoreText.text = string.Format("Score: {0}", GameManager.score);
            _canvas.enabled = true;
        }

        public void TryAgain()
        {
            GameManager.instance.SpawnPlayer();
            _canvas.enabled = false;
        }
    }
}
