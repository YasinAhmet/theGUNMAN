using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameObject player;

    void Start() {
        player = Player.Instance.gameObject;
    }
    // Start is called before the first frame update
    void Update() {

        if(player.GetComponent<Player>().isInBossFight) {
            player.GetComponent<Stats>().health += 5;
            Destroy(gameObject);
        }

        if(Vector3.Distance(transform.position, player.transform.position) > 5) {
            return;
        }

        if(Input.GetKeyDown(KeyCode.F)) {
            player.GetComponent<Stats>().health += 5;
            Destroy(gameObject);
        }
    }
}
