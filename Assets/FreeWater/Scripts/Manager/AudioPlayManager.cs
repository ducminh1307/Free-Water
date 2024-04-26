using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private AudioSource gunAudio;
    [SerializeField] private AudioSource winAudio;
    [SerializeField] private AudioSource loseAudio;
    [SerializeField] private AudioSource sfxAudio;

    private void Awake()
    {
        Weapon.onFire += OnFireCallback;
        Health.onPlayerDeath += OnLoseCallback;
        TimeManager.onWin += OnWinCallback;
    }

    private void OnDestroy()
    {
        Weapon.onFire -= OnFireCallback;
        Health.onPlayerDeath -= OnLoseCallback;
        TimeManager.onWin -= OnWinCallback;
    }

    private void Start()
    {
        SetVolumeAudio();
    }

    private void OnFireCallback()
    {
        gunAudio.Play();
    }

    private void OnWinCallback()
    {
        winAudio.Play();
    }

    private void OnLoseCallback()
    {
        loseAudio.Play();
    }

    private void SetVolumeAudio()
    {
        float volume = PlayerPrefs.GetFloat("musicValue");
        gunAudio.volume = volume;
        winAudio.volume = volume;
        loseAudio.volume = volume;
        sfxAudio.volume = volume;
    }
}
