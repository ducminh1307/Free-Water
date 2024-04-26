using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header(" Elemets ")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private Transform bulletPos;

    [Header(" Datas ")]
    [SerializeField] private GunSO gunSO;
    private int minDamage;
    private int maxDamage;
    private float timeBulletFire;

    [Header(" Events ")]
    public static Action onFire;

    private void Awake()
    {
        minDamage = gunSO.GetDataInstance().minDamage;
        maxDamage = gunSO.GetDataInstance().maxDamage;
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        Fire();
    }

    //Xoay sung
    private void RotateGun()
    {
        //Lay vi tri cua chuot
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Lay vector cua sung va chuot
        Vector2 lookDir = mousePosition - transform.position;
        //tinh goc do quay sung
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1, -1, 0);
        else 
            transform.localScale = new Vector3(1, 1, 0);
    }

    //Ham ban vien dan
    private void Fire()
    {
        timeBulletFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBulletFire <= 0)
        {
            onFire.Invoke();
            SpawmBullet();
        }
    }

    //Ham tao vien dan
    private void SpawmBullet()
    {
        //Khoang cach thoi gian ban dan
        timeBulletFire = gunSO.GetDataInstance().timeFire;

        GameObject bulletFire = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Bullet bu = bulletFire.GetComponent<Bullet>();
        //Tao thong so damage cho dan
        bu.SetMinDamage(minDamage);
        bu.SetMaxDamage(maxDamage);

        //Effect
        Instantiate(muzzle, bulletPos.position, transform.rotation, transform);

        //Tao luc day vien dan
        Rigidbody2D rb = bulletFire.GetComponent<Rigidbody2D>();
        Vector2 bulletDirection = (bulletPos.position - transform.position).normalized;
        rb.AddForce(bulletDirection * gunSO.GetDataInstance().bulletForce, ForceMode2D.Impulse);
    }

    public void DamageBuff(float timeBoost, int damageBuff)
    {
        StartCoroutine(OnDamageBuff(timeBoost, damageBuff));
    }
    IEnumerator OnDamageBuff(float timeBoost, int damageBuff)
    {
        minDamage += damageBuff;
        maxDamage += damageBuff;
        yield return new WaitForSeconds(timeBoost);
        minDamage -= damageBuff;
        maxDamage -= damageBuff;
    }
}
