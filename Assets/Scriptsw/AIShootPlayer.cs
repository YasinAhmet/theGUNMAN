using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootPlayer : MonoBehaviour
{
    public GameObject player;
    Stats stats;
    public Fire gunScript;
    public int reactionTime = 100;
    int reactionTimer = 0;
    public int reactionRange;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance.gameObject;
        stats = gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.isDead)
        {
            Destroy(gameObject.GetComponent<AIShootPlayer>());
            return;
        }

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > reactionRange)
        {
            return;
        }

        if (Physics.Linecast(transform.position, player.transform.position,1<<8)) 
        {
            return;
        }

        transform.LookAt(player.transform);
        reactionTimer++;

        if (reactionTimer == reactionTime)
        {
            Debug.DrawLine(transform.position,player.transform.position,Color.black, 1);
            reactionTimer = 0;
            ReactionofAI();
        }
    }

    public void ReactionofAI()
    {
        gunScript.SFire();
    }
}
