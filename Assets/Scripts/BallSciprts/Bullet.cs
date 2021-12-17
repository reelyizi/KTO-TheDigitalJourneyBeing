using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;

    public GameObject scoreText;
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
            AudioManager.instance.AudioPlay("Hit");
            Destroy(this.gameObject);
            GameObject obj = Instantiate(scoreText, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Holder").transform);
            obj.GetComponent<BubbleScoreText>().SetText(other.gameObject.GetComponent<Bubble>().score);
            GameManager.score += other.gameObject.GetComponent<Bubble>().score;
            other.gameObject.GetComponent<Bubble>().DestroyBubble(false);
        }
    }
}
