using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerChildTrigger : MonoBehaviour
{
    public GameObject group, holder;
    public PlayFabManager playFabManager;

    public GameObject energyShield;
    public GameObject[] uipanel;
    public GameObject laserWeapon,scorePanel;
    public TextMeshProUGUI finalScoreText;
    public GameManager gameManager;
    public TakeShareScreenShoot takeShareScreenShoot;
    public bool checkEnded = false;
    void Start()
    {
        foreach (GameObject obj in uipanel)
        {
            obj.SetActive(true);
        }
        checkEnded = false;
    }

    public float invinsibleDuration = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble") && !energyShield.activeInHierarchy && !checkEnded)
        {

            PlayerMovement playerMovement = transform.parent.GetComponent<PlayerMovement>();
            if (playerMovement.invinsible <= 0)
            {
                if (!playerMovement.armor)
                {
                    //death
                    checkEnded = true;
                    AudioManager.instance.AudioPlay("Dead");
                    //Ui paneli kapat
                    finalScoreText.text=GameManager.score.ToString();
                    scorePanel.SetActive(true);
                    foreach (GameObject obj in uipanel)
                    {
                        obj.SetActive(false);
                    }
                    //mermileri patlat.
                    GameObject[] bullets=GameObject.FindGameObjectsWithTag("Bullet");
                    foreach(GameObject bullet in bullets)
                    {
                        Destroy(bullet);
                    }
                    //Vibrator.Vibrate(100);
                    //text animasyonunu cikar
                    
                    //ss'i animasyonun bitisine kadar beklet
                    StartCoroutine(WaitAnimToss());
                    if (GameManager.score > GameManager.highScore)
                    {
                        PlayerPrefs.SetInt("HighScore", GameManager.score);
                        if (gameManager.gameNetworkStatus == GameManager.GameNetworkStatus.online)
                        {
                            playFabManager.SendLeaderboard(GameManager.score);
                        }
                    }
                    if (gameManager.gameNetworkStatus == GameManager.GameNetworkStatus.online)
                    {
                        playFabManager.GetLeaderBoardAroundPlayer();
                    }

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
    void Update()
    {
        if (takeShareScreenShoot.isTaked)
        {
            scorePanel.SetActive(false);
            Time.timeScale = 0f;
            holder.SetActive(false);
            group.SetActive(true);
            GameManager._instance.enabled = false;

        }
    }
    IEnumerator WaitAnimToss()
    {
        yield return new WaitForSeconds(0.5f);
        takeShareScreenShoot.ScreenShot();
        
    }
    private void CheckItems(Collider2D collision)
    {
        if (collision.name == "Grenade")
        {
            Destroy(collision.gameObject);
            GameManager._instance.ExplodeGrenade();

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
        else if (collision.name == "Chest")
        {
            Destroy(collision.gameObject);
            GameManager._instance.SetScoreText(1000, collision.transform);
        }
    }
}
