using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed=5f;

    // Start is called before the first frame update
    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity=new Vector2(0,speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Top")
        {
            Destroy(this.gameObject);
        }
        string[] name=other.name.Split();
        if(name.Length>1)
        {
            if(name[1]=="Ball")
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Bubble"))
        {
            other.gameObject.GetComponent<Bubble>().DestroyBubble();
        }
    }
}
