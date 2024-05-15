using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlaying = false;

    public float currentScore = 0f;


    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();
    public UnityEvent onVictory = new UnityEvent();

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
    }

    public void GameOver()
    {
        onGameOver.Invoke();
        isPlaying = false;
    }

    public void Victory()
    {
        onVictory.Invoke();
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
