using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainManager : MonoBehaviour
{
    //Them cac thanh phan trong UI
    [Header(" Elements ")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject selectCharacterPanel;
    [SerializeField] private GameObject resetProgessPrompt;

    private void Awake()
    {
        Time.timeScale = 1f;
        OpenMain();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //Hien Main MENU
    public void OpenMain()
    {
        mainPanel.SetActive(true);
        settingPanel.SetActive(false);
        selectCharacterPanel.SetActive(false);
        resetProgessPrompt.SetActive(false);
    }
    //Hien SETTING MENU
    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }
    //Dong SETTING MENU
    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }
    //Hien Chon nhan vat MENU
    public void OpenSelectCharacter()
    {
        mainPanel.SetActive(false);
        settingPanel.SetActive(false);
        selectCharacterPanel.SetActive(true);
        resetProgessPrompt.SetActive(false);
    }
    //Thoat game
    public void ExitButtonCallback()
    {
        //Thoat game trong che do Editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        //Thoat game khi build ra game
        Application.Quit();
    }
}
