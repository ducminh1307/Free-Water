using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "All Charater", menuName = ("Character/All CharacterData"))]
public class AllCharacters_SO : ScriptableObject
{
    public List<CharacterSO> characters;
}
