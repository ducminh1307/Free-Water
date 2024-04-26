using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Health Buff")]
public class HealthBuff : PowerUpEffect
{
    [SerializeField] private int healthBuff;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().HealBuff(healthBuff);
    }
}