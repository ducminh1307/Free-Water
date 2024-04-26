using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Bar healthBar;

    [Header(" Datas ")]
    [SerializeField] private float safeTimeDuration;
    private int maxHealth;
    private int currentHealth;
    private float safeTime;

    [Header(" Events ")]
    public static Action<Transform> onEnemyDeath;
    public static Action onPlayerDeath;

    private void Start()
    {
        if (healthBar != null)
            maxHealth = GetComponent<Player>().GetCharacter().health;
        else
            maxHealth = GetComponent<EnemyAI>().GetEnemy().health;

        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.UpdateBar(currentHealth, maxHealth);
    }

    void Update()
    {
        if (safeTime > 0)
        {
            safeTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if (safeTime <= 0)
        {
            currentHealth -= damage;

            if (healthBar != null)
            {
                healthBar.UpdateBar(currentHealth, maxHealth);
            }

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                if (healthBar == null)
                {
                    onEnemyDeath.Invoke(transform);
                }
                else
                {
                    onPlayerDeath.Invoke();
                }
            }
            
            safeTime = safeTimeDuration;
        }
    }

    public void HealBuff(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
}
