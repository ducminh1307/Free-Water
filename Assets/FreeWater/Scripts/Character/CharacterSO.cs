using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSO : ScriptableObject
{
    public int id;
    public string nameCharacter;
    public int health;
    public float speed;

    //Khoi tao kieu Character de de dang thao tac du lieu
    public Character GetDataInstance()
    {
        return new Character()
        {
            id = this.id,
            nameCharacter = this.nameCharacter,
            health = this.health,
            speed = this.speed
        };
    }
}
