using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed=10;
    private Rigidbody2D rb;
    public GameObject bullet;
    private float ScreenWidth;
    private bool canWalk;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        canWalk=true;canShoot=true;
        ScreenWidth=Screen.width;
        rb=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        int i=0;
        while(i<Input.touchCount)
        {
            if(Input.GetTouch(i).position.x>ScreenWidth/2)
            {
                //move right
                if(canWalk)
                {
                    MoveCharachter(1);
                }

            }
            if(Input.GetTouch(i).position.x<ScreenWidth/2)
            {
                //move left
                if(canWalk)
                {
                    MoveCharachter(-1);
                }
            }
            ++i;
        }
        if(Input.touchCount>=2)
        {
            if(canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
        #if UNITY_EDITOR
        MoveCharachter(Input.GetAxis("Horizontal"));
        #endif
    }
    public void MoveCharachter(float input)
    {
        rb.AddForce(new Vector2(input*moveSpeed*Time.deltaTime,0));
    }
    IEnumerator Shoot()
    {
        canWalk=false;
        canShoot=false;
        Vector2 temp=transform.position;
        temp.y+=1;
    
        //mekanik instantiate vs 
        Instantiate(bullet,temp,Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        temp.x+=0.3f;
        Instantiate(bullet,temp,Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        canShoot=true;
        yield return new WaitForSeconds(0.3f);
        canWalk=true;
        
    }
}
