using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _timer = 0f;
    private float _rateSpeedIncreasing;
    private float _valueSpeedIncreasing;

    private Camera _cam;

    private EnemyController _controller;
    
    private Vector3 viewportPoint;
    
    private void Awake() => _cam = Camera.main;

    private void OnEnable() 
    {
        if(!_controller)
            _controller = EnemyController.instance;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _controller.settings.fallSpeed * Time.deltaTime);

        HideObjUnderScreen();
    }

    private void HideObjUnderScreen()
    {
        viewportPoint = _cam.WorldToViewportPoint(transform.position);

        if(viewportPoint.y < 0)
            this.gameObject.SetActive(false);
    }
}
