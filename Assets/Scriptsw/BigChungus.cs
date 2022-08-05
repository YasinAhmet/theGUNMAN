using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigChungus : MonoBehaviour
{
    public GameObject player;
    public GameObject healthbar;
    public Slider slider;
	public Gradient gradient;
	public Image fill;
    public Stats stats;
    bool engagehapened = false;
    
    public GameObject bossFightPos;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance.gameObject;
        stats = gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 45 && !door.activeSelf) {
            healthbar.transform.parent.gameObject.SetActive(true);
            SetMaxHealth(stats.max_health);

            if(bossFightPos != null) {
                player.GetComponent<Player>().isInBossFight = true;
                player.transform.position = bossFightPos.transform.position;
                door.SetActive(true);
            }
        }

        if(healthbar.activeSelf == true) {
            SetHealth(stats.health);
        }
    }

    public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(int health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
