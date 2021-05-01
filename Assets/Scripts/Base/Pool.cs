using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: Thats a base class for other T objects, if i would try to create pool of any obj not just GameObject
//so u cant create a SO instance of it

namespace Slider.Base
{
    //[CreateAssetMenu(fileName = "New Pool", menuName = "SO/Pool/Base", order = 0)]
    public abstract class  Pool<T> : ScriptableObject
    {
        public T objToSpawn;
        public int maxAmountObjects = 10;

        protected Queue<T> _pool = new Queue<T>();

        public abstract void Spawn(Vector3 spawnPos, Quaternion rotation, System.Action<T> OnPooled);

        public abstract int GetPoolLength();

        public abstract void ClearPool();
    }
}
