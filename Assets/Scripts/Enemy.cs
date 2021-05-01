using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Camera _cam;

    private GameManager _controller;
    
    private Vector3 viewportPoint;
    
    private void Awake() => _cam = Camera.main;

    private void OnEnable() 
    {
        if(!_controller)
            _controller = GameManager.instance;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _controller.settings.fallSpeed * Time.deltaTime);

        HideObjUnderScreen();
    }

    private void HideObjUnderScreen()
    {
        viewportPoint = _cam.WorldToViewportPoint(transform.position);

        if(viewportPoint.y < -0.3f)
        {
            this.gameObject.SetActive(false);
            IncreaseScore();
        }
    }

    private void IncreaseScore() => GameManager.score += 1;
}
