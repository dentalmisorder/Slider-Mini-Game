using System;
using UnityEngine;

namespace Slider.Base
{
    [CreateAssetMenu(fileName="New GameObject Pool", menuName="SO/Pool/Pool of GameObjects")]
    public class PoolObjects : Pool<GameObject>
    {
        public override void Spawn(Vector3 spawnPos, Quaternion rotation, Action<GameObject> OnPooled)
        {
            if((_pool.Count == 0 || _pool.Peek().activeSelf) && _pool.Count < maxAmountObjects)
            {
                GameObject temp = Instantiate(objToSpawn, spawnPos, rotation);
                OnPooled?.Invoke(temp);
                _pool?.Enqueue(temp);
            }
            else
            {
                GameObject temp = _pool?.Dequeue();
                temp.transform.position = spawnPos;
                temp.transform.rotation = rotation;
                temp.SetActive(true);
                OnPooled?.Invoke(temp);
                _pool?.Enqueue(temp);
            }
        }

        public override int GetPoolLength() => _pool.Count;

        public override void ClearPool()
        {
            foreach (GameObject obj in _pool)
                Destroy(obj.gameObject);

            _pool.Clear();
        }
    }   
}
