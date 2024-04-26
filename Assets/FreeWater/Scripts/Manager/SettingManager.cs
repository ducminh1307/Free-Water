using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject resetProgess;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [Header(" Actions ")]
    public static Action<float> onSFXValueChanged;

    [Header(" Datas ")]
    private float sfxValue;
    private float musicValue;
    private int highScore;
    private const string sfxValueKey = "sfxValue";
    private const string musicValueKey = "musicValue";
    private const string highScoreKey = "highScore";
    
    //Load du lieu tu PlayerPrefs
    private void Awake()
    {
        LoadData();
    }
    //Su kien khi keo thanh slider SFX
    public void SFXSliderChangedCallback()
    {
        onSFXValueChanged.Invoke(sfxSlider.value);
        SaveData();
    }
    //Su kien khi keo thanh slider Music
    public void MusicSliderChangedCallback()
    {
        SaveData();
    }
    //Luu du lieu cua SFX  va Music vao PlayerPrefs
    public void SaveData()
    {
        PlayerPrefs.SetFloat(sfxValueKey, sfxSlider.value);
        PlayerPrefs.SetFloat(musicValueKey, musicSlider.value);
    }
    //Lay du lieu cua tu PlayerPrefs
    public void LoadData()
    {
        if (!PlayerPrefs.HasKey(sfxValueKey))
            PlayerPrefs.SetFloat(sfxValueKey, 1f);
        if (!PlayerPrefs.HasKey(musicValueKey))
            PlayerPrefs.SetFloat(musicValueKey, 1f);
        if (!PlayerPrefs.HasKey(highScoreKey))
            PlayerPrefs.SetInt(highScoreKey, 0);

        sfxValue = PlayerPrefs.GetFloat(sfxValueKey);
        musicValue = PlayerPrefs.GetFloat(musicValueKey);
        highScore = PlayerPrefs.GetInt(highScoreKey);

        sfxSlider.value = sfxValue;
        musicSlider.value = musicValue;
        highScoreText.text = $"HIGH SCORE: {highScore}";

    }
    //Su kien an nut Reset
    public void ResetButtonCallback()
    {
        resetProgess.SetActive(true);
    }
    //Su kien khi an Yes
    public void ResetYes()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    //Su kien khi an No
    public void ResetNo()
    {
        resetProgess.SetActive(false);
    }
}
