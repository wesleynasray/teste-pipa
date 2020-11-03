using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHistory : MonoBehaviour
{
    #region Static Elements
    private static BallHistory m_Instance;
    private static BallHistory Instance => m_Instance == null ? m_Instance = FindObjectOfType<BallHistory>() : m_Instance;
    
    public static bool HasNumber(int number) => Instance.calledNumbers.Contains(number);
    #endregion

    [SerializeField] Ball ballPrefab;
    [SerializeField] int ballCount = 5;
    [SerializeField] float padding = 100;

    Ball[] balls = { };
    List<int> calledNumbers = new List<int>();    

    private void Awake()
    {
        SpawnBalls();
        Game.OnBallCalled += AddNumber;
    }

    private void SpawnBalls()
    {
        balls = new Ball[ballCount];
        for (int i = 0; i < ballCount; i++)
        {
            balls[i] = Instantiate(ballPrefab, transform);
            balls[i].transform.localPosition = new Vector2 {
                x = i * padding,
                y = 0
            };
            balls[i].gameObject.SetActive(false);

            if (i > 0)
                balls[i].transform.localScale *= .75f;
        }
    }

    private void AddNumber(int number)
    {
        calledNumbers.Add(number);
        UpdateBalls();
    }

    private void UpdateBalls()
    {
        for (int i = 0; i < balls.Length && i < calledNumbers.Count; i++)
        {
            balls[i].gameObject.SetActive(true);
            balls[i].SetBall(calledNumbers[calledNumbers.Count - 1 - i]);
        }
    }    
}
