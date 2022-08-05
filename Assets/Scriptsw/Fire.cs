using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float velocitySpeed;
    public float recoil = 0.05f;
    public bool ownedByPlayer;

    public GameObject gunFocus;
    public GameObject gunPosition;
    bool focusToggled = false;

    public GameObject spawnPosition;
    public GameObject spawnRotation;

    public GameObject ammo;
    public GameObject ammostash;
    public Stats stats;

    public List<GameObject> fires = new List<GameObject>();

    void Start()
    {
        if (!ownedByPlayer)
        {
            ammostash = Player.Instance.stash;
        }
    }

    void Update()
    {
        if (ownedByPlayer)
        {
            if (stats.isDead)
            {
                Destroy(gameObject.GetComponent<AIShootPlayer>());
                return;
            }

            if (Input.GetMouseButtonDown(1))
            {
                ChangeScope();
            }

            if (Input.GetMouseButtonDown(0))
            {
                SFire();
            }

        }

        moveBullets();
    }

    public void moveBullets() {
        foreach (GameObject fire in fires)
        {
            if (fire == null)
            {
                fires.Remove(fire);
                continue;
            }

            fire.GetComponent<Rigidbody>().velocity = fire.transform.forward.normalized * velocitySpeed;
        }
    }

    public void ChangeScope()
    {
        if (!focusToggled)
        {
            transform.position = gunFocus.transform.position;
            focusToggled = true;
        }

        else if (focusToggled)
        {
            transform.position = gunPosition.transform.position;
            focusToggled = false;
        }
    }


    public void SFire()
    {
        Vector3 g = spawnRotation.transform.eulerAngles;
        float r = Random.Range(-recoil, recoil);

        if (!ownedByPlayer)
        {
            g += new Vector3(r, r, r);
        }

        fires.Add(Instantiate(ammo, spawnPosition.transform.position, Quaternion.Euler(g.x,g.y,g.z), ammostash.transform));
    }
}
