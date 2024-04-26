using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header(" Elemets ")]
    [SerializeField] private AudioSource music;

    //Them su kien khi keo Slider thay doi am luong
    private void Awake()
    {
        SettingManager.onSFXValueChanged += SFXSliderChangedCallback;
    }
    //Xoa su kien khi bi huy
    private void OnDestroy()
    {
        SettingManager.onSFXValueChanged -= SFXSliderChangedCallback;
    }

    //Ham thay doi am luong de su dung trong Event onSFXValueChanged
    public void SFXSliderChangedCallback(float value)
    {
        music.volume = value;
    }
}
