using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject pausePanel;

    GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void PlayButtonHandler()
    {
        gm.StartGame();
        gm.ResetScore();
    }

    public void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void ActivateVictoryUI()
    {
        victoryUI.SetActive(true);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
