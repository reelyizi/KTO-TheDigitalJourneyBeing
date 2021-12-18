using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    private float timer;
    [SerializeField] private float duration;
    void Update()
    {
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
