using System;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public static event Action OnGameStart;

    protected void Awake ()
	{
        OnGameStart?.Invoke();
    }
}
