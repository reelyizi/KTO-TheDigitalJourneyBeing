using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] public GameObject bossHead, bossLeftHand, bossRightHand;
    [SerializeField] private List<Transform> bubbleHoles = new List<Transform>();
    [SerializeField] private GameObject bossBubble;
    [SerializeField] private List<Sprite> bossBubbleSprites;
    [Range(1, 30)] [SerializeField] float minBubbleSpawnRate, maxBubbleSpawnRate;
    private List<float> spawnRate;
    private float timer = 0;
    [SerializeField] private float bossHeadHealth, bossLeftHandHealth, bossRightHandHealth;
    [SerializeField] private List<Sprite> bossHeadSprite, bossLeftHandSprite, bossRightHandSprite;
    private int bossHeadHealthCounter = 3, bossLeftHandHealthCounter = 3, bossRightHandHealthCounter = 3;
    private float saveBossHeadHealth, saveBossLeftHandHealth, saveBossRightHandHealth;

    [SerializeField] private GameObject scoreText;
    [SerializeField] private int bossHeadScore, bossHandScore;
    GameManager gameManager;

    public float colorChangingSpeed = 10f;
    public float bossMovementSpeed = 10f;
    private Vector3 headStartPos, leftHandStartPos, rightHandStartPos;
    [SerializeField] private bool isBossDead;
    private List<Transform> cloneBubbleHoles;
    private string currentBossMSC;

    #region Properties

    public float BossHeadHealth
    {
        get { return bossHeadHealth; }
        set
        {
            bossHead.GetComponent<SpriteRenderer>().material.color = Color.red;
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
            bossLeftHand.GetComponent<SpriteRenderer>().material.color = Color.red;
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
            bossRightHand.GetComponent<SpriteRenderer>().material.color = Color.red;
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
        //Boss entering msc
        AudioManager.instance.AudioStop(AudioManager.instance.currentMSC);
        currentBossMSC = "Boss_Music_0" + Random.Range(0, 2);
        AudioManager.instance.AudioPlay(currentBossMSC);

        gameManager=GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        saveBossHeadHealth = BossHeadHealth;
        saveBossRightHandHealth = BossRightHandHealth;
        saveBossLeftHandHealth = BossLeftHandHealth;

        headStartPos = bossHead.transform.position;
        leftHandStartPos = bossLeftHand.transform.position;
        rightHandStartPos = bossRightHand.transform.position;
        cloneBubbleHoles = new List<Transform>(bubbleHoles);
        //handsDestroyed=false;
        //Screen Shake And Vibration
        if (gameManager.gameVibrationStatus == GameManager.GameVibrationStatus.on)
        {
            Vibrator.Vibrate(1000);
        }
        Shake.start = true;
        //
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
                    GameObject obj = Instantiate(bossBubble, cloneBubbleHoles[i].position, Quaternion.identity, GameObject.Find("Bubble").transform);
                    obj.GetComponent<SpriteRenderer>().sprite = bossBubbleSprites[Random.Range(0, bossBubbleSprites.Count)];
                    obj.GetComponent<Bubble>().startDirection = cloneBubbleHoles[i].GetComponent<BubbleDirection>().bubbleStartDirection;
                    obj.GetComponent<Bubble>().applyForce = true;
                    //spawnRate[i] = Random.Range(minBubbleSpawnRate, maxBubbleSpawnRate);
                    spawnRate.RemoveAt(i);
                    cloneBubbleHoles.RemoveAt(i);
                }
            }
            if (!cloneBubbleHoles.Any())
            {
                SetSpawnRate(0);
                cloneBubbleHoles = new List<Transform>(bubbleHoles);
                timer = 0f;
            }
        }
    }

    private void MoveBoss()
    {
        if (!isBossDead)
        {
            bossHead.transform.position = Vector3.Lerp(bossHead.transform.position, Vector3.up * (Camera.main.pixelHeight / 100 - (bossHead.GetComponent<BoxCollider2D>().bounds.size.y * 2)), bossMovementSpeed * Time.deltaTime);
            bossRightHand.transform.position = Vector3.Lerp(bossRightHand.transform.position, Vector3.right * (Camera.main.pixelWidth / 100 - (bossRightHand.GetComponent<BoxCollider2D>().bounds.size.x * 2)), bossMovementSpeed * Time.deltaTime);
            bossLeftHand.transform.position = Vector3.Lerp(bossLeftHand.transform.position, Vector3.right * (0 - (bossLeftHand.GetComponent<BoxCollider2D>().bounds.size.x / 2)), bossMovementSpeed * Time.deltaTime);
        }
        else
        {
            bossHead.transform.position = Vector3.Lerp(bossHead.transform.position, headStartPos, bossMovementSpeed * Time.deltaTime);
            bossRightHand.transform.position = Vector3.Lerp(bossRightHand.transform.position, rightHandStartPos, bossMovementSpeed * Time.deltaTime);
            bossLeftHand.transform.position = Vector3.Lerp(bossLeftHand.transform.position, leftHandStartPos, bossMovementSpeed * Time.deltaTime);
        }

        //if (leftHandDestroyed)
        //    bossLeftHand.transform.position = Vector3.Lerp(bossLeftHand.transform.position, leftHandStartPos, bossMovementSpeed * Time.deltaTime);
        //if (rightHandDestroyed)
        //    bossRightHand.transform.position = Vector3.Lerp(bossRightHand.transform.position, rightHandStartPos, bossMovementSpeed * Time.deltaTime);
    }

    private void CheckHealthStatus()
    {
        /*if(bossLeftHandHealth==0 && bossRightHandHealth==0 && !handsDestroyed)
        {
            //Hands destroyed and give feedback
            handsDestroyed=true;
            GameManager._instance.ExplodeGrenade();
        }*/
        CheckWoundedStatus();

        if (bossLeftHandHealth == 0 && bossLeftHand.GetComponent<BoxCollider2D>().enabled)
        {
            AudioManager.instance.AudioPlay("Monster_Roar_0" + Random.Range(0, 6));

            //Left Hand Destroyed And Vibrate FeedBack
            GameManager._instance.ExplodeGrenade();
            bossLeftHand.GetComponent<BoxCollider2D>().enabled = false;
            //leftHandDestroyed = true;
            bossLeftHand.GetComponent<Animator>().SetTrigger("Back");
            //SetScore(bossHandScore, bossLeftHand.transform);
        }
        if (bossRightHandHealth == 0 && bossRightHand.GetComponent<BoxCollider2D>().enabled)
        {
            //Left Hand Destroyed And Vibrate FeedBack
            GameManager._instance.ExplodeGrenade();
            bossRightHand.GetComponent<BoxCollider2D>().enabled = false;
            //rightHandDestroyed = true;
            bossRightHand.GetComponent<Animator>().SetTrigger("Back");
            SetScore(bossHandScore, bossRightHand.transform);
        }
        if (bossHeadHealth == 0 && bossHead.GetComponent<BoxCollider2D>().enabled)
        {
            //Boss dead msc
            AudioManager.instance.AudioStop(currentBossMSC);           
            AudioManager.instance.AudioPlay(AudioManager.instance.RandomLevelMusic());


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
                StartCoroutine(WaitAndExplode());
            }

            Destroy(gameObject, 2f);
        }
    }

    private void CheckWoundedStatus()
    {
        float _bossHeadHealthCounter = bossHeadHealthCounter;
        float _bossRightHandHealthCounter = bossRightHandHealthCounter;
        float _bossLeftHandHealthCounter = bossLeftHandHealthCounter;

        if (BossHeadHealth < saveBossHeadHealth * (_bossHeadHealthCounter / 3.5f) && saveBossHeadHealth > 1)
        {
            bossHead.GetComponent<SpriteRenderer>().sprite = bossHeadSprite[--bossHeadHealthCounter];
        }

        if (BossLeftHandHealth < saveBossLeftHandHealth * (_bossLeftHandHealthCounter / 3.5f) && saveBossLeftHandHealth > 1)
        {
            bossLeftHand.GetComponent<SpriteRenderer>().sprite = bossLeftHandSprite[--bossLeftHandHealthCounter];
        }

        if (BossRightHandHealth < saveBossRightHandHealth * (_bossRightHandHealthCounter / 3.5f) && BossRightHandHealth > 1)
        {
            bossRightHand.GetComponent<SpriteRenderer>().sprite = bossRightHandSprite[--bossRightHandHealthCounter];
        }
    }

    IEnumerator WaitAndExplode()
    {
        yield return new WaitForSeconds(1f);
        GameManager._instance.ExplodeGrenade();
    }

    private void ColorStatus()
    {
        if (bossHead.GetComponent<SpriteRenderer>().material.color != Color.white)
        {
            Color currentColor = bossHead.GetComponent<SpriteRenderer>().material.color;
            currentColor = new Color((currentColor.r + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.r + (Time.deltaTime * colorChangingSpeed)),
                (currentColor.g + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.g + (Time.deltaTime * colorChangingSpeed)),
                (currentColor.b + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.b + (Time.deltaTime * colorChangingSpeed)));
            bossHead.GetComponent<SpriteRenderer>().material.color = currentColor;
        }

        if (bossLeftHand.GetComponent<SpriteRenderer>().material.color != Color.white)
        {            
            Color currentColor = bossLeftHand.GetComponent<SpriteRenderer>().material.color;
            currentColor = new Color((currentColor.r + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.r + (Time.deltaTime * colorChangingSpeed)),
                (currentColor.g + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.g + (Time.deltaTime * colorChangingSpeed)),
                (currentColor.b + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.b + (Time.deltaTime * colorChangingSpeed)));
            bossLeftHand.GetComponent<SpriteRenderer>().material.color = currentColor;
        }

        if (bossRightHand.GetComponent<SpriteRenderer>().material.color != Color.white)
        {
            Color currentColor = bossRightHand.GetComponent<SpriteRenderer>().material.color;
            currentColor = new Color((currentColor.r + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.r + (Time.deltaTime * colorChangingSpeed)),
                (currentColor.g + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.g + (Time.deltaTime * colorChangingSpeed)),
                (currentColor.b + (Time.deltaTime * colorChangingSpeed) > 1 ? 1 : currentColor.b + (Time.deltaTime * colorChangingSpeed)));
            bossRightHand.GetComponent<SpriteRenderer>().material.color = currentColor;
        }
    }

    private void SetSpawnRate(float additionalTime)
    {
        spawnRate = new List<float>();
        for (int i = 0; i < bubbleHoles.Count; i++)
        {
            spawnRate.Add(Random.Range(minBubbleSpawnRate, maxBubbleSpawnRate) + additionalTime);
        }
    }

    public void SetScore(int score, Transform limbPos)
    {
        GameManager.score += score;
        GameObject obj = Instantiate(scoreText, Camera.main.WorldToScreenPoint(new Vector3(Random.Range(limbPos.position.x - 3, limbPos.position.x + 3), Random.Range(limbPos.position.y - 2, limbPos.position.y + 2), limbPos.position.z)), Quaternion.identity, GameObject.Find("Holder").transform);
        obj.GetComponent<BubbleScoreText>().SetText(score);
    }

}
