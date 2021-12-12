using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed=10;
    private Rigidbody2D rb;
    public GameObject bullet;
    private float ScreenWidth;
    private bool canWalk,isWalk=false;
    private bool canShoot;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
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
        if(Input.touchCount==0)
        {
            animator.SetBool("isWalk",false);
            isWalk=false;
        }
        if(Input.touchCount>=2)
        {
            canWalk=false;
            if(canShoot)
                StartCoroutine(Shoot_());
        }
        
        

        #if UNITY_EDITOR
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {   
            canWalk=false;
            if(canShoot)
                StartCoroutine(Shoot_());
            //StartCoroutine(Shoot());
        }
        if(canWalk)
        {
            MoveCharachter(Input.GetAxis("Horizontal"));
        }
        if(!Input.anyKey)
        {
            animator.SetBool("isWalk",false);
            isWalk=false;
        }
        #endif
    }
    public void MoveCharachter(float input)
    {
        isWalk=true;
        animator.SetBool("isWalk",true);
        transform.position+=new Vector3(input*moveSpeed*Time.deltaTime,0,0);
    }
    IEnumerator Shoot_()
    {
        animator.SetBool("isShoot",true);
        canWalk=false;
        canShoot=false;
        Vector2 temp=transform.position;
        temp.y+=1;
        //mekanik instantiate vs 
        Instantiate(bullet,temp,Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(bullet,temp,Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(bullet,temp,Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        canShoot=true;
        canWalk=true;
        animator.SetBool("isShoot",false); 
    }
}
