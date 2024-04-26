using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private Rigidbody2D rb;
    private Animator animator;

    [Header(" Datas ")]
    [SerializeField] private AllCharacters_SO charactersSO;
    private Character character;
    private float speed;
    private Vector2 moveDirection;

    //khai bao bien cho Roll
    [SerializeField] private float RollTime;
    private float rollTime;
    private bool rollOnce;
    [SerializeField] private float rollBoost;

    private void Awake()
    {
        character = charactersSO.characters[PlayerPrefs.GetInt("id")].GetDataInstance();
        speed = character.speed;
        Health.onPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        Health.onPlayerDeath -= OnPlayerDeath;
    }

    void Start()
    {
        SetActiveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        RotateCharacter();
        ProcessInput();
        Roll();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
    }

    public void RotateCharacter()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.x < mousePosition.x)
        {
            animator.transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            animator.transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    private void SetActiveCharacter()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
            if (i == PlayerPrefs.GetInt("id"))
                transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }
        animator = transform.GetChild(0).GetChild(PlayerPrefs.GetInt("id")).GetComponent<Animator>();
    }

    public void Roll()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            animator.SetBool("Roll", true);
            rollTime = RollTime;
            speed += rollBoost;
            rollOnce = true;
        }
        if (rollTime <= 0 && rollOnce == true)
        {
            animator.SetBool("Roll", false);
            speed -= rollBoost;
            rollOnce = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }
    }

    private void OnPlayerDeath()
    {
        this.enabled = false;
    }

    public Character GetCharacter()
    {
        return character;
    }

    public void SpeedBuff(float timeBoost, float speedBuff)
    {
        StartCoroutine(OnSppedBuff(timeBoost, speedBuff));
    }

    IEnumerator OnSppedBuff(float timeBoost, float speedBuff)
    {
        speed += speedBuff;
        yield return new WaitForSeconds(timeBoost);
        speed -= speedBuff;
    }
}
