using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bubble : MonoBehaviour
{
    [SerializeField] private GameObject expEffects;
    private Rigidbody2D rigidbody;
    [SerializeField] private float limitSpeedX;
    [SerializeField] private float limitSpeedY;
    [SerializeField] private float startForce;

    [SerializeField] private GameObject bubble = null;

    [SerializeField] public Vector2 startDirection = Vector2.one;
    [SerializeField] private float angle;
    [SerializeField] private bool calculateStartAngle;
    public int score = 10;
    public bool applyForce;

    [SerializeField] private float percintile = 5f;
    public Vector2 velocity;

    public GameObject scoreText;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (applyForce)
            ApplyStartForce(startDirection.normalized);

        //rigidbody.velocity = new Vector2(limitSpeedX, limitSpeedY) * startDirection.normalized;
    }

    void Update()
    {
        rigidbody.velocity = new Vector2((rigidbody.velocity.x > limitSpeedX ? limitSpeedX : rigidbody.velocity.x) * GameManager._instance.timescale,
            (rigidbody.velocity.y > limitSpeedY ? limitSpeedY : rigidbody.velocity.y) * GameManager._instance.timescale);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    velocity = rigidbody.velocity;
        //    rigidbody.gravityScale = 0;
        //    rigidbody.velocity = Vector2.zero;
        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    rigidbody.gravityScale = 1;
        //    rigidbody.velocity = velocity;
        //}


    }

    public void DestroyBubble()
    {
        AudioManager.instance.AudioPlay("Hit");
        if (bubble != null)
        {
            GameObject bubbleObject = Instantiate(bubble, transform.position, Quaternion.identity, transform.parent);

            bubbleObject.GetComponent<Rigidbody2D>().velocity = (rigidbody.velocity.y > 0 ? rigidbody.velocity : -rigidbody.velocity);
            bubbleObject = Instantiate(bubble, transform.position, Quaternion.identity, transform.parent);

            Vector3 findReverseOfVelocity = Quaternion.AngleAxis(180, Vector3.up) * (rigidbody.velocity.y > 0 ? rigidbody.velocity : -rigidbody.velocity);
            //findReverseOfVelocity = Quaternion.AngleAxis(0, Vector3.up) * findReverseOfVelocity;            
            bubbleObject.GetComponent<Rigidbody2D>().velocity = findReverseOfVelocity;

            CreateEffect();
            Destroy(this.gameObject);
        }
        else
        {
            CreateEffect();
            Destroy(this.gameObject);
        }
        GameManager.score += score;
        GameManager._instance.TryToGetItems(percintile, transform.position);
        GameObject obj = Instantiate(scoreText, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Holder").transform);
        obj.GetComponent<BubbleScoreText>().SetText(score);
    }

    private void CreateEffect()
    {
        GameObject expEffect = Instantiate(expEffects, transform.position, Quaternion.identity);
        Destroy(expEffect, 0.2f);
    }

    private void ApplyStartForce(Vector2 direction)
    {
        rigidbody.AddForce(Quaternion.AngleAxis(angle, Vector3.forward) * direction.normalized * startForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rigidbody.velocity = Vector2.up * limitSpeedY;
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            DestroyBubble();
        }
    }

    private void OnDrawGizmos()
    {
        if (rigidbody != null)
        {
            Gizmos.color = Color.magenta;

            Vector3 t = rigidbody.velocity.y > 0 ? rigidbody.velocity.normalized : -rigidbody.velocity.normalized;
            t = Quaternion.AngleAxis(180, Vector3.up) * t;
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + (rigidbody.velocity.y > 0 ? rigidbody.velocity.normalized : -rigidbody.velocity.normalized));
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + (new Vector2(t.x, t.y)));
        }

        if (calculateStartAngle)
        {
            startDirection = Quaternion.AngleAxis(angle, Vector3.forward) * startDirection;
            calculateStartAngle = !calculateStartAngle;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + startDirection);
    }
}
