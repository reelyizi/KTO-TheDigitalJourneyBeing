using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildTrigger : MonoBehaviour
{
    public GameObject group,holder;
    public PlayFabManager playFabManager;

    public GameObject energyShield;
    public GameObject laserWeapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble") && !energyShield.activeInHierarchy)
        {
            PlayerMovement playerMovement = transform.parent.GetComponent<PlayerMovement>();
            if (!playerMovement.armor && playerMovement.invinsible <= 0)
            {
                AudioManager.instance.AudioPlay("Dead");
                Time.timeScale = 0f;
                if (GameManager.score > GameManager.highScore)
                {
                    PlayerPrefs.SetInt("HighScore", GameManager.score);
                    playFabManager.SendLeaderboard(GameManager.score);
                }
                playFabManager.GetLeaderBoard();
                holder.SetActive(false);
                group.SetActive(true);
                GameManager._instance.enabled = false;
            }
            else
                playerMovement.armor = false;
        }
        else
        {
            CheckItems(collision);
        }
    }

    private void CheckItems(Collider2D collision)
    {
        if(collision.name == "Grenade")
        {
            Destroy(collision.gameObject);
            for (int i = 0; i < GameObject.Find("Bubble").transform.childCount; i++)
            {
                GameObject.Find("Bubble").transform.GetChild(i).GetComponent<Bubble>().DestroyBubble(true);
            }            
        }
        else if(collision.name == "Armor")
        {
            Destroy(collision.gameObject);
            transform.parent.GetComponent<PlayerMovement>().armor = true;
        }
        else if (collision.name == "Invinsible")
        {
            Destroy(collision.gameObject);
            transform.parent.GetComponent<PlayerMovement>().invinsible = 3f;
        }
        else if (collision.name == "Energy Shield")
        {
            Destroy(collision.gameObject);
            energyShield.SetActive(true);
        }
        else if (collision.name == "Laser Weapon")
        {
            Destroy(collision.gameObject);
            laserWeapon.SetActive(true);
        }
    }
}
