using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        Time.timeScale = 1f;
        Health.onPlayerDeath += LoseGame;
        TimeManager.onWin += WinGame;
    }

    private void OnDestroy()
    {
        Health.onPlayerDeath -= LoseGame;
        TimeManager.onWin -= WinGame;
    }

    private void LoseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
