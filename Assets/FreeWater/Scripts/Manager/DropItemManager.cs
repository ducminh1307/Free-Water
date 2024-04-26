using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private UnityEngine.Object[] dropItems;
    [SerializeField] private Transform dropItemParent;

    [Header(" Datas ")]
    [SerializeField]
    [Range(0, 1)] private float ratelDropItem;

    private void Awake()
    {
        Health.onEnemyDeath += OnEnemyDeath;
    }

    private void OnDestroy()
    {
        Health.onEnemyDeath -= OnEnemyDeath;
    }

    private void OnEnemyDeath(Transform trf)
    {
        float rateRandom = UnityEngine.Random.Range(0f, 1f);

        if (rateRandom > ratelDropItem)
            return;

        int itemIndex = UnityEngine.Random.Range(0, dropItems.Length);
        
        Instantiate(dropItems[itemIndex], trf.position, Quaternion.identity, dropItemParent);
    }
}
