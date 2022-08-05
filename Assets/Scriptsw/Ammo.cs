using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammoDestroySchledule = 500;
    int count = 0;
    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Creature") {
            collision.collider.GetComponent<Stats>().health -= 1;

            if(collision.collider.GetComponent<PlayerMovement>() != null) {
                if(collision.collider.GetComponent<PlayerMovement>().isAntForm) {
                    collision.collider.GetComponent<Stats>().health -= 2;
                }
            }
        }

        Destroy(gameObject);
    }

    void Update() {
        count++;

        if(count >= ammoDestroySchledule) {
            Destroy(gameObject);
        }
    }
}
