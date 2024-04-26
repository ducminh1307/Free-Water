using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySO : ScriptableObject
{
    public string nameEnemy;
    public int health;
    public int minDamage;
    public int maxDamage;
    public float speed;

    public Enemy GetDataInstance()
    {
        return new Enemy()
        {
            nameEnemy = nameEnemy,
            health = health,
            maxDamage = maxDamage,
            minDamage = minDamage,
            speed = speed
        };
    }
}
