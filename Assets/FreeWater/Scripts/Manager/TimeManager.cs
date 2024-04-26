using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI timeText;

    [Header(" Timer ")]
    [SerializeField] private int timePlay;
    private int timer;
    private bool timerOn;

    [Header(" Events ")]
    public static Action onWin;

    void Start()
    {
        StartTime();
        StartCoroutine(StartTimer());
    }

    private void Update()
    {
        if (!timerOn)
            StopAllCoroutines();
    }

    IEnumerator StartTimer()
    {
        int showTimer;
        while (true)
        {
            timer++;
            
            showTimer = timePlay - timer;
            if (timer == timePlay)
                StopTime();

            DisplayTime(showTimer);
            yield return new WaitForSeconds(1f);
        }
    }

    void DisplayTime(int time)
    {
        float minutes = time / 60;
        float seconds = time % 60;

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void StartTime()
    {
        timer = 0;
        timerOn = true;
    }

    private void StopTime()
    {
        onWin.Invoke();
        timerOn = false;
    }

}
