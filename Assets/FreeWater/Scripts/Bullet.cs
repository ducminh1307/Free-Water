using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int minDamage;
    private int maxDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            int damage = Random.Range(minDamage, maxDamage);
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetMinDamage(int minDamage)
    {
        this.minDamage = minDamage;
    }

    public void SetMaxDamage(int maxDamage)
    {
        this.maxDamage = maxDamage;
    }
}
