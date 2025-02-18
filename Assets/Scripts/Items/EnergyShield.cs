using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyShield : MonoBehaviour
{
    public GameObject enemyTimer;
    [HideInInspector] public float timer;
    public float duration;
    void Update()
    {
        enemyTimer.GetComponent<TextMeshProUGUI>().text = ((Mathf.Round(timer * 100)) / 100.0).ToString();
        timer -= Time.deltaTime;        
        if (timer <= 0)
            this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        timer = duration;
        enemyTimer.SetActive(true);
    }

    private void OnDisable()
    {
        AudioManager.instance.AudioStop("Electric_Shield");
        enemyTimer.GetComponent<TextMeshProUGUI>().text = "0";
        enemyTimer.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            collision.GetComponent<Bubble>().DestroyBubble();
        }
    }
}
