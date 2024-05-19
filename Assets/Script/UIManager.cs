using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject perkPanel;

    GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
        gm.onVictory.AddListener(ActivateVictoryUI);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenPerksTree();
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

    public void OpenPerksTree()
    {
        perkPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
