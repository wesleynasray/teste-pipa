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

    #region Event Listening
    private void OnEnable()
    {
        Slot.OnSlotMarked += Slot_OnSlotMarked;
    }    
    private void OnDisable()
    {
        Slot.OnSlotMarked -= Slot_OnSlotMarked;
    }
    #endregion

    private void Start()
    {
        OnGameStart?.Invoke();
        StartCoroutine(CallBalls());
    }

    private IEnumerator CallBalls()
    {
        var wait = new WaitForSeconds(ballDelay);

        while (enabled)
        {
            OnBallCalled?.Invoke(Random.Range(1, 76));
            yield return wait;
        }
    }

    private void Slot_OnSlotMarked(Slot slot)
    {
        CheckBingo();
    }

    private void CheckBingo()
    {
        // CheckCollumns()
        // CheckRows()
        // CheckDiagonals()
        // CheckCorners()
    }
}
