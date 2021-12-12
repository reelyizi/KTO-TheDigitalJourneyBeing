using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score=0;
    public float levelTime = 180;
    private float startTime;
    public TextMeshProUGUI text,scoreText;
    public GameObject totalBubble;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timerControl = Time.time - startTime;
        //levelTime = (int)Time.time / 60;
        text.text = (levelTime - (int)timerControl % levelTime).ToString();
        scoreText.text=score.ToString();
        if(totalBubble.transform.childCount == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
