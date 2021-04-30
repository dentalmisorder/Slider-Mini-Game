using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static Action OnGameOver;

    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponentInChildren<Canvas>(true);
    }
}
