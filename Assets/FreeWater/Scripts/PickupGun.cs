using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject gun;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Destroy(collision.transform.GetChild(1).gameObject);
            Destroy(gameObject);
            gun.name = "Weapon";
            Instantiate(gun, collision.transform);
        }
    }
}
