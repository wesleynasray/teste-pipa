using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public static event Action OnGameStart;
    public static event Action OnGameEnd;
    public static event Action<int> OnBallCalled;

    [SerializeField] float ballDelay = 5;

    protected void Awake ()
	{
        OnGameStart?.Invoke();
        StartCoroutine(CallBalls());
    }

    private IEnumerator CallBalls()
    {
        var wait = new WaitForSeconds(ballDelay);

        while (enabled)
        {
            yield return wait;
            OnBallCalled?.Invoke(Random.Range(1, 76));
        }
    }
}
