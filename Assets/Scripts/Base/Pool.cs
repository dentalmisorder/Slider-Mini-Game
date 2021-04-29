using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Pool<T> : MonoBehaviour
{
    protected Predicate<T> _predicate;
    protected Queue<T> _pool;

    public Pool()
    {
        _pool = new Queue<T>();
        _predicate = new Predicate<T>(IsTrue);
    }

    public abstract T Spawn(Vector3 spawnPos, Quaternion rotation, Predicate<T> predicate);

    public abstract bool IsTrue(T objToCheck);
}
