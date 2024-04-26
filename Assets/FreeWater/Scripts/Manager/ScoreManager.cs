using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] TextMeshProUGUI scoreWinText;
    [SerializeField] TextMeshProUGUI scoreLoseText;

    [Header(" Datas ")]
    [SerializeField] private int scoreTime;
    private int currentScore;

    private void Awake()
    {
        LoadScore();
        Health.onPlayerDeath += ShowScore;
        TimeManager.onWin += SaveScoreToNextMap;
        TimeManager.onWin += ShowScore;
        Health.onEnemyDeath += UpdateScore;
    }

    private void OnDestroy()
    {
        Health.onPlayerDeath -= ShowScore;
        TimeManager.onWin -= SaveScoreToNextMap;
        TimeManager.onWin -= ShowScore;
        Health.onEnemyDeath -= UpdateScore;
    }

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("score"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShowScore()
    {
        scoreWinText.text = currentScore.ToString();
        scoreLoseText.text = currentScore.ToString();
        SaveScore();
        SaveScoreToNextMap();
    }

    private void SaveScore()
    {
        if (!PlayerPrefs.HasKey("highScore"))
            PlayerPrefs.SetInt("highScore", currentScore);
        else
        {
            if(PlayerPrefs.GetInt("highScore") < currentScore)
            {
                PlayerPrefs.SetInt("highScore", currentScore);
            }
        }
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("score"))
            currentScore = PlayerPrefs.GetInt("score");
        currentScore = 0;
    }

    private void UpdateScore(Transform trf)
    {
        currentScore += scoreTime; ;
    }

    private void SaveScoreToNextMap()
    {
        PlayerPrefs.SetInt("score", currentScore);
    }
}
