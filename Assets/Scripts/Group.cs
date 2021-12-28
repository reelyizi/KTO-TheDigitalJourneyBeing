using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Group : MonoBehaviour
{
    public TextMeshProUGUI scoreValueText, timerValueText;
    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        scoreValueText.text = GameManager.score.ToString();
        timerValueText.text = ((int)GameManager.timerControl).ToString();
    }
    public void RestartGame()
    {
        GameManager.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
