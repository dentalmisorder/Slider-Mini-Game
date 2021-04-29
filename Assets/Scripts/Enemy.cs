using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _timer = 0f;

    private float _fallSpeed;
    private float _rateSpeedIncreasing;
    private float _valueSpeedIncreasing;

    private Camera _cam;

    private Vector3 viewportPoint;
    
    private void Awake() => _cam = Camera.main;

    private void OnEnable()
    {
        _timer = Time.time + EnemyController.instance.settings.rateSpeedIncreasing;
        _fallSpeed = EnemyController.instance.settings.fallSpeed;
        _rateSpeedIncreasing = EnemyController.instance.settings.rateSpeedIncreasing;
        _valueSpeedIncreasing = EnemyController.instance.settings.valueSpeedIncreasing;
    }

    private void Update()
    {
        viewportPoint = _cam.WorldToViewportPoint(transform.position);

        if(Time.time > _timer)
        {
            _timer += _rateSpeedIncreasing;
            _fallSpeed += _valueSpeedIncreasing;
        }
        else
            transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime);

        if(viewportPoint.y < 0)
            this.gameObject.SetActive(false);
    }
}
