using System;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine;

namespace Slider.Base
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : MonoBehaviour
    {
        #region static/private fields

        public static Action<Vector2> OnTouchPressed;
        public static Action<Vector2> OnTouchReleased;
        public static Action<Vector2> OnTouchHold;

        private PlayerInputs playerInputs;

        #endregion

        private void Awake() => playerInputs = new PlayerInputs();

        private void OnEnable()
        {
            playerInputs.Enable();
            EnhancedTouchSupport.Enable();
        }

        private void OnDisable() 
        { 
            playerInputs.Disable();
            EnhancedTouchSupport.Disable();
        }

        private void Start()
        {
            playerInputs.PlayerInput.PressTouch.started += context => OnTouchPressed?.Invoke(playerInputs.PlayerInput.PressTouch.ReadValue<Vector2>());
            playerInputs.PlayerInput.PressTouch.started += context => OnTouchReleased?.Invoke(playerInputs.PlayerInput.PressTouch.ReadValue<Vector2>());
        }

        public void Update()
        {
            if(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches.Count > 0)
                OnTouchHold?.Invoke(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0].screenPosition);
        }
    }
}