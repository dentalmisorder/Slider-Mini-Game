using System.Collections;
using UnityEngine;
using Slider.Base;
using Slider.Gameplay;

public class GameManager : MonoBehaviour
{
    //NOTE: I feel bad for using singleton instead of observer pattern or something but its a Manager, so i guess its ok since its only 1 manager
    public static GameManager instance;
    public static uint score;

    public ChangableValues settings;

    [Space]
    public PoolObjects enemiesPool;
    public GameObject playerPfb;

    private float _defFallSpeed;
    private float _defSpawnRate;
    private float _timer = 0;
    private Camera _cam;

    private void Awake() 
    {
        instance = this;
        _cam = Camera.main;

        _defFallSpeed = settings.fallSpeed;
        _defSpawnRate = settings.spawnRate;
    }

    private void Start() => InvokeRepeating(nameof(IncreaseFallSpeed),0, settings.rateSpeedIncreasing);

    private void Update() => SpawnEnemy();

    private void SpawnEnemy()
    {
        if(Time.time > _timer)
        {
            _timer += settings.spawnRate;
            IncreaseSpawnSpeed();

            if(settings.enemiesToSpawn > 1)
            {
                StartCoroutine(SpawnWithDelay());
            }
            else
                enemiesPool.Spawn(_cam.ViewportToWorldPoint(new Vector3(Random.Range(0.2f, 0.9f), 1f, _cam.nearClipPlane + 1f)), Quaternion.identity, (_) => {});
        }
    }

    public void SpawnPlayer()
    {
        SetDefaultParams(); //Resetting default fall speed/spawn rate/etc.

        Player player = playerPfb.GetComponent<Player>(); //To get the player height on the screen

        Instantiate(playerPfb, _cam.ViewportToWorldPoint(new Vector3(0.5f, player.settings.playerHeight, _cam.nearClipPlane + 1f)), playerPfb.transform.rotation);
    }

    private void IncreaseSpawnSpeed()
    {
        if(settings.spawnRate - settings.spawnRateDecrement > settings.minimumSpawnRate)
            settings.spawnRate -= settings.spawnRateDecrement;
    }

    private void SetDefaultParams()
    {
        settings.fallSpeed = _defFallSpeed;
        settings.spawnRate = _defSpawnRate;

        enemiesPool.ClearPool();
        Time.timeScale = 1f;
    }

    private void IncreaseFallSpeed() => settings.fallSpeed += settings.valueSpeedIncreasing;

    private IEnumerator SpawnWithDelay()
    {
        for (int i = 0; i < settings.enemiesToSpawn; i++)
        {
            enemiesPool.Spawn(_cam.ViewportToWorldPoint(new Vector3(Random.Range(0.2f, 0.9f), 1f, _cam.nearClipPlane + 1f)), Quaternion.identity, (_) => {});
            yield return new WaitForSeconds(Random.Range(settings.minValueRandomSpawn, settings.minimumSpawnRate - 0.1f));
        }
        yield break;
    }

    #region SETTINGS CLASS

    [System.Serializable]
    public class ChangableValues
    {
        [Space, Header("Hints are avaliable (put cursor on variable names)"), Space]

        [Tooltip("X enemies will be spawned after spawnRate seconds")]
        public int enemiesToSpawn = 1;

        [Tooltip("If you wanna insert delay between enemiesToSpawn enemies (if > 1), minValue of random X (maxValue is minimumSpawnRate - 0.1f)")]
        public float minValueRandomSpawn = 0.1f;

        [Tooltip("Speed of enemies falling to the bottom of the screen")] 
        public float fallSpeed = 2f;

        [Tooltip("Every X seconds fallSpeed will be increased for valueSpeedIncreasing")]
        public float rateSpeedIncreasing = 5f;

        [Tooltip("Every rateSpeedIncreasing seconds fall speed will increase by X")]
        public float valueSpeedIncreasing = 2f;

        [Tooltip("How often enemies will be spawned (every X seconds)")] 
        public float spawnRate = 5f;

        [Tooltip("Every %spawnRate% seconds spawn will be faster for X seconds (you can leave it 0 to make spawnRate constant)")] 
        public float spawnRateDecrement = 1f;

        [Tooltip("Minimum delay between spawns (if spawnRateDecrement are not 0)")] 
        public float minimumSpawnRate = 0.5f;
    }

    #endregion
}
