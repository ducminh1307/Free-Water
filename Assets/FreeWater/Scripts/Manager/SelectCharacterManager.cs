using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacterManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private AllCharacters_SO allCharacter;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI speedText;
    private List<Character> characterList = new List<Character>();

    void Start()
    {
        foreach(CharacterSO character in allCharacter.characters)
        {
            characterList.Add(character.GetDataInstance());
        }
        //Load thong tin nhan vat nguoi choi da chon lan truoc
        CheckIdPlayerPrefs();
        CharacterSelectCallback(PlayerPrefs.GetInt("id"));
    }
    //Hien thong tin nhan vat khi nguoi choi chon nhan vat
    public void CharacterSelectCallback(int id)
    {
        //Luu id nhan vat cua nguoi choi da chon
        PlayerPrefs.SetInt("id", id);

        if (id < characterList.Count && characterList[id] != null)
        {
            nameText.text = characterList[id].nameCharacter;
            healthText.text = characterList[id].health.ToString();
            speedText.text = characterList[id].speed.ToString();
        }
        else
        {
            nameText.text = "Unknow";
            healthText.text = "0";
            speedText.text = "0";
        }
    }
    //Kiem tra truoc do nguoi choi da chon nhan vat chua
    private void CheckIdPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("id"))
            PlayerPrefs.SetInt("id", 0);
    }
    //Su kien khi an nut Start game
    public void StartGameButtonCallback()
    {
        SceneManager.LoadScene("Map1");
    }
}
