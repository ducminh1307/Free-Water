using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI barText;

    public void UpdateBar(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
        barText.text = $"{currentValue}/{maxValue}";
    }
}
