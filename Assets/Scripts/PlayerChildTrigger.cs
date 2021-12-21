using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildTrigger : MonoBehaviour
{
    public GameObject group, holder;
    public PlayFabManager playFabManager;

    public GameObject energyShield;
    public GameObject laserWeapon;

    public float invinsibleDuration = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble") && !energyShield.activeInHierarchy)
        {
            PlayerMovement playerMovement = transform.parent.GetComponent<PlayerMovement>();
            if(playerMovement.invinsible <= 0)
            {
                if (!playerMovement.armor)
                {
                    AudioManager.instance.AudioPlay("Dead");
                    Time.timeScale = 0f;
                    if (GameManager.score > GameManager.highScore)
                    {
                        PlayerPrefs.SetInt("HighScore", GameManager.score);
                        playFabManager.SendLeaderboard(GameManager.score);
                    }
                    playFabManager.GetLeaderBoardAroundPlayer();
                    holder.SetActive(false);
                    group.SetActive(true);
                    GameManager._instance.enabled = false;
                }
                else
                {
                    playerMovement.armor = false;
                    collision.gameObject.GetComponent<Bubble>().DestroyBubble();
                }
            }  
        }
        else
        {
            CheckItems(collision);
        }
    }

    private void CheckItems(Collider2D collision)
    {
        if (collision.name == "Grenade")
        {
            Destroy(collision.gameObject);
            List<GameObject> bubbles = new List<GameObject>();
            for (int i = 0; i < GameObject.Find("Bubble").transform.childCount; i++)
            {
                bubbles.Add(GameObject.Find("Bubble").transform.GetChild(i).gameObject);
            }
            Vibrator.Vibrate(250);
            foreach (GameObject bubble in bubbles)
            {
                bubble.GetComponent<Bubble>().DestroyBubble();
                //Screen Shake Vibration
                Shake.start=true;
                
            }
            
        }
        else if (collision.name == "Armor")
        {
            Destroy(collision.gameObject);
            transform.parent.GetComponent<PlayerMovement>().armor = true;
        }
        else if (collision.name == "Invinsible")
        {
            Destroy(collision.gameObject);
            transform.parent.GetComponent<PlayerMovement>().invinsible = invinsibleDuration;
        }
        else if (collision.name == "Energy Shield")
        {
            Destroy(collision.gameObject);
            if (energyShield.activeInHierarchy)
                energyShield.GetComponent<EnergyShield>().timer = energyShield.GetComponent<EnergyShield>().duration;
            energyShield.SetActive(true);
        }
        else if (collision.name == "Laser Weapon")
        {
            Destroy(collision.gameObject);
            laserWeapon.SetActive(true);
        }
    }
}
