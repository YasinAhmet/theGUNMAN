using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int max_health;
    public int health;
    public GameObject layDownPos;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) {
            return;
        }

        if(health < 1) {
            transform.position = layDownPos.transform.position;
            transform.rotation = layDownPos.transform.rotation;
            isDead = true;
        }
    }
}
