using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "PowerUps/Damage Buff")]
public class DamageBuff : PowerUpEffect
{
    [SerializeField] private float timeBoost;
    [SerializeField] private int damage;

    public override void Apply(GameObject target)
    {
        target.transform.GetChild(1).GetComponent<Weapon>().DamageBuff(timeBoost, damage);
    }
}
