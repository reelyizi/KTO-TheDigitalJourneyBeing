using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private GameObject bossHead, bossLeftHand, bossRightHand;
    [SerializeField] private List<Transform> bubbleHoles = new List<Transform>();
    [SerializeField] private GameObject bossBubble;
    [SerializeField] private List<Sprite> bossBubbleSprites;
    [Range(1, 30)] [SerializeField] float minBubbleSpawnRate, maxBubbleSpawnRate;
    private List<float> spawnRate;
    private float timer = 0;
    [SerializeField] private float bossHeadHealth, bossLeftHandHealth, bossRightHandHealth;

    [SerializeField] private GameObject scoreText;
    [SerializeField] private int bossHeadScore, bossHandScore;

    public float colorChangingSpeed = 10f;
    public float bossMovementSpeed = 10f;
    private Vector3 headStartPos, leftHandStartPos, rightHandStartPos;
    private bool isBossDead, leftHandDestroyed, rightHandDestroyed;

    #region Properties

    public float BossHeadHealth
    {
        get { return bossHeadHealth; }
        set
        {
            bossHead.GetComponent<SpriteRenderer>().color = Color.red;
            bossHeadHealth -= value;
            if (bossHeadHealth <= 0)
            {
                bossHeadHealth = 0;
            }
        }
    }
    public float BossLeftHandHealth
    {
        get { return bossLeftHandHealth; }
        set
        {
            bossLeftHand.GetComponent<SpriteRenderer>().color = Color.red;
            bossLeftHandHealth -= value;
            if (bossLeftHandHealth <= 0)
            {
                bossLeftHandHealth = 0;
            }
        }
    }
    public float BossRightHandHealth
    {
        get { return bossRightHandHealth; }
        set
        {
            bossRightHand.GetComponent<SpriteRenderer>().color = Color.red;
            bossRightHandHealth -= value;
            if (bossRightHandHealth <= 0)
            {
                bossRightHandHealth = 0;
            }
        }
    }

    #endregion

    void Start()
    {
        headStartPos = bossHead.transform.position;
        leftHandStartPos = bossLeftHand.transform.position;
        rightHandStartPos = bossRightHand.transform.position;
        SetSpawnRate(1.5f);
    }

    void Update()
    {
        CheckHealthStatus();
        ColorStatus();
        //MoveBoss();
        timer += Time.deltaTime;
        if (!isBossDead)
        {
            for (int i = 0; i < spawnRate.Count; i++)
            {
                if (timer >= spawnRate[i])
                {
                    spawnRate.RemoveAt(i);
                    GameObject obj = Instantiate(bossBubble, bubbleHoles[i].position, Quaternion.identity, GameObject.Find("Bubble").transform);
                    obj.GetComponent<SpriteRenderer>().sprite = bossBubbleSprites[Random.Range(0, bossBubbleSprites.Count)];
                    obj.GetComponent<Bubble>().applyForce = true;
                    //spawnRate[i] = Random.Range(minBubbleSpawnRate, maxBubbleSpawnRate);
                }
            }
            if (timer >= maxBubbleSpawnRate)
            {
                SetSpawnRate(0);
                timer = 0f;
            }
        }
    }

    private void MoveBoss()
    {
        if (!isBossDead)
        {
            bossHead.transform.position = Vector3.Lerp(bossHead.transform.position, Vector3.up * (Camera.main.pixelHeight / 100 - (bossHead.GetComponent<BoxCollider2D>().bounds.size.y* 2)), bossMovementSpeed * Time.deltaTime);
            bossRightHand.transform.position = Vector3.Lerp(bossRightHand.transform.position, Vector3.right * (Camera.main.pixelWidth / 100 - (bossRightHand.GetComponent<BoxCollider2D>().bounds.size.x* 2)), bossMovementSpeed * Time.deltaTime);
            bossLeftHand.transform.position = Vector3.Lerp(bossLeftHand.transform.position, Vector3.right * (0 - (bossLeftHand.GetComponent<BoxCollider2D>().bounds.size.x / 2)), bossMovementSpeed * Time.deltaTime);
        }
        else
        {
            bossHead.transform.position = Vector3.Lerp(bossHead.transform.position, headStartPos, bossMovementSpeed * Time.deltaTime);
            bossRightHand.transform.position = Vector3.Lerp(bossRightHand.transform.position, rightHandStartPos, bossMovementSpeed * Time.deltaTime);
            bossLeftHand.transform.position = Vector3.Lerp(bossLeftHand.transform.position, leftHandStartPos, bossMovementSpeed * Time.deltaTime);
        }

        if (leftHandDestroyed)
            bossLeftHand.transform.position = Vector3.Lerp(bossLeftHand.transform.position, leftHandStartPos, bossMovementSpeed * Time.deltaTime);
        if (rightHandDestroyed)
            bossRightHand.transform.position = Vector3.Lerp(bossRightHand.transform.position, rightHandStartPos, bossMovementSpeed * Time.deltaTime);
    }

    private void CheckHealthStatus()
    {
        if (bossLeftHandHealth == 0 && bossLeftHand.GetComponent<BoxCollider2D>().enabled)
        {
            bossLeftHand.GetComponent<BoxCollider2D>().enabled = false;
            //leftHandDestroyed = true;
            bossLeftHand.GetComponent<Animator>().SetTrigger("Back");
            SetScore(bossHandScore, bossLeftHand.transform);
        }
        if (bossRightHandHealth == 0 && bossRightHand.GetComponent<BoxCollider2D>().enabled)
        {
            bossRightHand.GetComponent<BoxCollider2D>().enabled = false;
            //rightHandDestroyed = true;
            bossRightHand.GetComponent<Animator>().SetTrigger("Back");
            SetScore(bossHandScore, bossRightHand.transform);
        }
        if (bossHeadHealth == 0 && bossHead.GetComponent<BoxCollider2D>().enabled)
        {
            isBossDead = true;
            bossHead.GetComponent<BoxCollider2D>().enabled = false;
            //SetScore(bossHeadScore, bossHead.transform);

            bossHead.GetComponent<Animator>().SetTrigger("Back");
            if (bossRightHand.GetComponent<BoxCollider2D>().enabled)
                bossRightHand.GetComponent<Animator>().SetTrigger("Back");
            if (bossLeftHand.GetComponent<BoxCollider2D>().enabled)
                bossLeftHand.GetComponent<Animator>().SetTrigger("Back");

            GameManager._instance.bossCounter++;
            GameManager._instance.isBossActive = false;
            GameManager._instance.bossDead = true;
            for (int i = 0; i < 4; i++)
            {
                Vibrator.Vibrate(250);
                Shake.start = true;
                StartCoroutine(WaitAndExplode());
            }

            Destroy(gameObject, 2f);
        }
    }
    IEnumerator WaitAndExplode()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager._instance.ExplodeGrenade();
    }

    private void ColorStatus()
    {
        if (bossHead.GetComponent<SpriteRenderer>().color != Color.white)
            bossHead.GetComponent<SpriteRenderer>().color = Color.Lerp(bossHead.GetComponent<SpriteRenderer>().color, Color.white, Time.deltaTime * colorChangingSpeed);
        if (bossLeftHand.GetComponent<SpriteRenderer>().color != Color.white)
            bossLeftHand.GetComponent<SpriteRenderer>().color = Color.Lerp(bossLeftHand.GetComponent<SpriteRenderer>().color, Color.white, Time.deltaTime * colorChangingSpeed);
        if (bossRightHand.GetComponent<SpriteRenderer>().color != Color.white)
            bossRightHand.GetComponent<SpriteRenderer>().color = Color.Lerp(bossRightHand.GetComponent<SpriteRenderer>().color, Color.white, Time.deltaTime * colorChangingSpeed);
    }

    private void SetSpawnRate(float additionalTime)
    {
        spawnRate = new List<float>();
        for (int i = 0; i < bubbleHoles.Count; i++)
        {
            spawnRate.Add(Random.Range(minBubbleSpawnRate, maxBubbleSpawnRate) + additionalTime);
        }
    }

    private void SetScore(int score, Transform limbPos)
    {
        GameManager.score += score;
        GameObject obj = Instantiate(scoreText, Camera.main.WorldToScreenPoint(limbPos.position), Quaternion.identity, GameObject.Find("Holder").transform);
        obj.GetComponent<BubbleScoreText>().SetText(score);
    }
}
