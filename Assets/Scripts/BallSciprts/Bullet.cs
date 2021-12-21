using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Top")
        {
            Destroy(this.gameObject);
        }
        string[] name = other.name.Split();
        if (name.Length > 1)
        {
            if (name[1] == "Ball")
            {
                Destroy(this.gameObject);
            }
        }
        if (other.gameObject.CompareTag("Bubble"))
        {
            Destroy(this.gameObject);                        
            other.gameObject.GetComponent<Bubble>().DestroyBubble();
        }
    }
}
