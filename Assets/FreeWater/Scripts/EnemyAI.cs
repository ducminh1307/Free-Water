using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header(" Elements ")]
    private Animator animator;
    private GameObject player;

    [Header(" Datas ")]
    [SerializeField] private EnemySO enemySO;
    private Enemy enemy;
    private Health playerHealth;

    private void Awake()
    {
        enemy = enemySO.GetDataInstance();
        Health.onEnemyDeath += OnEnemyDeath;
    }

    private void OnDestroy()
    {
        Health.onEnemyDeath -= OnEnemyDeath;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RotateEnemy();
        FollowCharacter();
    }
    //Xoay enemy theo Player
    public void RotateEnemy()
    {
        Vector3 playerPosition = player.transform.position;
        if (transform.position.x < playerPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }
    //Duoi theo Player
    private void FollowCharacter()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * enemy.speed;
    }

    public Enemy GetEnemy()
    {
        return enemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth = collision.GetComponent<Health>();
            InvokeRepeating("DamagePlayer", 0, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke("DamagePlayer");
        playerHealth = null;
    }

    //Ham chay animation Death trong Action onEnemyDeath
    public void OnEnemyDeath(Transform trf)
    {
        if(gameObject == trf.gameObject)
            animator.Play("Death");
    }

    void DamagePlayer()
    {
        int damage = Random.Range(enemy.minDamage, enemy.maxDamage);
        playerHealth.TakeDamage(damage);
    }

    //Ham xoa player trong animation
    public void Death()
    {
        Destroy(this.gameObject);
    }
}
