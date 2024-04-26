using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSO : ScriptableObject
{
    public string nameGun;
    public int minDamage;
    public int maxDamage;
    public float timeFire;
    public float bulletForce;

    public Gun GetDataInstance()
    {
        return new Gun()
        {
            nameGun = this.nameGun,
            minDamage = this.minDamage,
            maxDamage = this.maxDamage,
            timeFire = this.timeFire,
            bulletForce = this.bulletForce
        };
    }
}
