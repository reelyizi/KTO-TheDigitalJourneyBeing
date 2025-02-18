using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject invisibleTimer;
    public Transform baseWeaponMuzzle;
    public float moveSpeed = 10, mobilemoveSpeed = 150;
    private Rigidbody2D rb;
    public GameObject bullet;
    private float ScreenWidth;
    private bool canWalk, isWalk = false;
    private bool canShoot;
    Animator animator;

    [HideInInspector] public bool armor;
    [SerializeField] private GameObject armorImage;
    public float invinsible;
    bool alphaState;
    [SerializeField] float alpha = 1;
    void Start()
    {
        animator = GetComponent<Animator>();
        canWalk = true; canShoot = true;
        ScreenWidth = Screen.width;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (invinsible > 0)
        {
            invinsible -= Time.deltaTime;
            invisibleTimer.SetActive(true);
            invisibleTimer.GetComponent<TextMeshProUGUI>().text = ((Mathf.Round(invinsible * 100)) / 100.0).ToString();
            if (GetComponent<SpriteRenderer>().color.a > .2f && !alphaState)
            {
                alpha -= Time.deltaTime;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
                if (alpha < .2)
                    alphaState = true;
            }
            else if (alphaState)
            {
                alpha += Time.deltaTime;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
                if (alpha > 1)
                    alphaState = false;
            }
        }
        else
        {
            invisibleTimer.GetComponent<TextMeshProUGUI>().text = "0";
            invisibleTimer.SetActive(false);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if (armor)
        {
            armorImage.SetActive(true);
        }
        else
            armorImage.SetActive(false);
    }

    void FixedUpdate()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                if (canShoot)
                {
                    StartCoroutine(Shoot_());
                }


            }
            ++i;
        }
        if (Input.touchCount == 0)
        {
            animator.SetBool("isWalk", false);
            isWalk = false;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(1))
        {

            canWalk = false;
            if (canShoot)
                StartCoroutine(Shoot_());
        }


        MoveCharachter(Input.GetAxis("Horizontal"), moveSpeed);
        if (!Input.anyKey)
        {
            animator.SetBool("isWalk", false);
            isWalk = false;
        }
    }
    public void MoveCharachter(float input, float speed)
    {
        if (input != 0)
            GameManager._instance.isWalkForTutorial = true;
        isWalk = true;
        animator.SetBool("isWalk", true);
        transform.position += new Vector3(input * speed * Time.deltaTime, 0, 0);
    }
    IEnumerator Shoot_()
    {
        GameManager._instance.isShootFortutorial = true;
        AudioManager.instance.AudioPlay("Fire");
        animator.SetBool("isShoot", true);
        canWalk = false;
        canShoot = false;

        Instantiate(bullet, baseWeaponMuzzle.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(bullet, baseWeaponMuzzle.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(bullet, baseWeaponMuzzle.position, Quaternion.identity);
        canShoot = true;
        canWalk = true;
        animator.SetBool("isShoot", false);
    }
}
