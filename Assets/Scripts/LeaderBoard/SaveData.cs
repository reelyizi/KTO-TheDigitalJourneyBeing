using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveData : MonoBehaviour
{
    public TMP_InputField myScore,myName;
    private int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SendScore()
    {
        currentScore=int.Parse(myScore.text);
        if(currentScore>=PlayerPrefs.GetInt("highScore",0))
        {
            PlayerPrefs.SetInt("highScore",currentScore);
            HighScores.UploadScore(myName.text,currentScore);
        }
    }
}
