using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLifeDestroyer : MonoBehaviour
{
    public float Time;
    void Start()
    {
        Destroy(this.gameObject, Time);
    }
}
