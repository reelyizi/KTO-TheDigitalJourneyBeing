using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    public int damage = 10;
    
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
        CheckBossCollider(other);
    }

    private void CheckBossCollider(Collider2D other)
    {
        if(other.gameObject.name == "Boss Left Hand")
        {
            Destroy(this.gameObject);
            other.transform.parent.GetComponent<BossManager>().BossLeftHandHealth = damage;
            other.transform.parent.GetComponent<BossManager>().SetScore(50,other.transform.parent.GetComponent<BossManager>().bossLeftHand.transform);
        }
        else if (other.gameObject.name == "Boss Right Hand")
        {
            Destroy(this.gameObject);
            other.transform.parent.GetComponent<BossManager>().BossRightHandHealth = damage;
            other.transform.parent.GetComponent<BossManager>().SetScore(50,other.transform.parent.GetComponent<BossManager>().bossRightHand.transform);
        }
        else if (other.gameObject.name == "Boss Head")
        {
            Destroy(this.gameObject);
            //Vibration HeadShot
            other.transform.parent.GetComponent<BossManager>().BossHeadHealth = damage;
        }
    }
}
