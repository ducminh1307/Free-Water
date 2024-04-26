using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Killed : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI killedText;

    [Header(" Datas ")]
    private int currentKilled = 0;

    private void Awake()
    {
        Health.onEnemyDeath += UpdateKilled;
    }

    private void Start()
    {
        killedText.text = "0";
    }

    public void UpdateKilled(Transform trf)
    {
        currentKilled++;
        killedText.text = $"{currentKilled}";
    }

    public int GetCurrentKill()
    {
        return currentKilled;
    }
}
