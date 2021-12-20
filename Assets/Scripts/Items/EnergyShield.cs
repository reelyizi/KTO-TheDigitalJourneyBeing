using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    [HideInInspector] public float timer;
    [HideInInspector] public float duration;
    void Update()
    {
        Debug.Log(timer);
        timer -= Time.deltaTime;
        if (timer <= 0)
            this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        timer = duration;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            collision.GetComponent<Bubble>().DestroyBubble();
        }
    }
}
