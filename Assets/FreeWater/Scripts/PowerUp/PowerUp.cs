using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private PowerUpEffect effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            effect.Apply(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
}
