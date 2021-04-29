using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider.Base;

public class EnemyController : MonoBehaviour
{
    //NOTE: I feel bad for using singleton instead of observer pattern or something but its a Manager, so i guess its ok
    public static EnemyController instance;

    public ChangableValues settings;

    public PoolObjects enemiesPool;

    private float _timer = 0;
    private Camera _cam;

    private void Awake() 
    {
        instance = this;
        _cam = Camera.main;
    }

    private void Update()
    {
        if(Time.time > _timer)
        {
            _timer += settings.rateSpeedIncreasing;
            enemiesPool.Spawn(_cam.ViewportToWorldPoint(new Vector3(Random.Range(0.2f, 0.9f), 1f, _cam.nearClipPlane + 1f)), Quaternion.identity, (_) => Debug.Log(_));
        }
    }

    [System.Serializable]
    public class ChangableValues
    {
        public float fallSpeed = 2f;
        public float rateSpeedIncreasing = 5f;
        public float valueSpeedIncreasing = 2f;
    }
}
