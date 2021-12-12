using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bubble : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float limitSpeed;
    [SerializeField] private float startForce;

    [SerializeField] private GameObject bubble = null;

    private Vector2 startDirection = Vector2.one;
    [SerializeField] private float angle;
    [SerializeField] private bool calculateStartAngle;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ApplyStartForce(startDirection.normalized);
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x > limitSpeed ? limitSpeed : rigidbody.velocity.x,
            rigidbody.velocity.y > limitSpeed ? limitSpeed : rigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && bubble != null)
        {
            DestroyBubble();
        }
    }

    public void DestroyBubble()
    {
        if(bubble != null)
        {
            GameObject bubbleObject = Instantiate(bubble, transform.position, Quaternion.identity, transform.parent);

            bubbleObject.GetComponent<Rigidbody2D>().velocity = rigidbody.velocity;
            bubbleObject = Instantiate(bubble, transform.position, Quaternion.identity, transform.parent);

            Vector3 findReverseOfVelocity = Quaternion.AngleAxis(180, Vector3.right) * -rigidbody.velocity;
            findReverseOfVelocity = Quaternion.AngleAxis(0, Vector3.up) * findReverseOfVelocity;
            bubbleObject.GetComponent<Rigidbody2D>().velocity = findReverseOfVelocity;

            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void ApplyStartForce(Vector2 direction)
    {
        rigidbody.AddForce(Quaternion.AngleAxis(angle, Vector3.forward) * direction.normalized * startForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnDrawGizmos()
    {
        if (rigidbody != null)
        {
            Gizmos.color = Color.magenta;
            Vector3 t = Quaternion.AngleAxis(180, Vector3.right) * -rigidbody.velocity.normalized * 1;
            t = Quaternion.AngleAxis(0, Vector3.up) * t;
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + (rigidbody.velocity.normalized * 1));
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
