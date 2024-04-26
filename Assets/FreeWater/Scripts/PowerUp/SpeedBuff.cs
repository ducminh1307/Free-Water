using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Speed Buff")]
public class SpeedBuff : PowerUpEffect
{
    [SerializeField] private float timeBoost;
    [SerializeField] private float speed;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().SpeedBuff(timeBoost, speed);
    }
}
