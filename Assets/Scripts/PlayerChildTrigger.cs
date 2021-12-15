using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildTrigger : MonoBehaviour
{
    public GameObject group,holder;
    public PlayFabManager playFabManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            AudioManager.instance.AudioPlay("Dead");
            Time.timeScale=0f;
            if(GameManager.score>GameManager.highScore)
            {
                PlayerPrefs.SetInt("HighScore",GameManager.score);
                playFabManager.SendLeaderboard(GameManager.score);
            }
            playFabManager.GetLeaderBoard();
            holder.SetActive(false);
            group.SetActive(true);
            GameManager._instance.enabled = false;
            
        }        
    }
}
