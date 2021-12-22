using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public static int score = 0;
    public static float timerControl = 0;
    public float levelTime = float.MaxValue;
    private float startTime;
    public TextMeshProUGUI text, scoreText;
    public GameObject totalBubble, group;
    [Range(1, 999)] public float maxSpawnRate;
    [Range(1, 999)] public float minSpawnRate;

    public Transform A, B;
    public GameObject bigBubble;
    [SerializeField] float timer;
    public static bool isGameStart = false;
    public static int highScore;
    public float timescale;

    public float itemCooldownTimer = 3f;
    private float CDtimer = 0f;
    [SerializeField] List<GameObject> items;
    public GameObject boss;
    [HideInInspector] public int bossCounter = 0;
    [HideInInspector] public bool isBossActive;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        group.SetActive(false);
        startTime = Time.time;
        timer = Random.Range(minSpawnRate, maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            score += 10000;
        }
        if (!isGameStart)
        {
            //Time.timeScale=0f;
            startTime = Time.time;
        }
        else
        {
            Time.timeScale = 1f;
            timerControl = Time.time - startTime;
            //levelTime = (int)Time.time / 60;
            text.text = ((int)timerControl).ToString();
            scoreText.text = score.ToString();
            if (totalBubble.transform.childCount == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    SpawnBubble();
                }
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SpawnBubble();
            }
            BossCheck();
        }
        if (itemCooldownTimer > 0)
        {
            itemCooldownTimer -= Time.deltaTime;
        }
    }

    private void BossCheck()
    {
        if (score >= 50000 + (bossCounter * 200000) && !isBossActive)
        {
            isBossActive = true;
            Instantiate(boss, Vector3.zero, Quaternion.identity);
        }
    }

    private void SpawnBubble()
    {
        timer = Random.Range(minSpawnRate, maxSpawnRate);
        GameObject obj = Instantiate(bigBubble, new Vector2(Random.Range(A.position.x, B.position.x), A.position.y), Quaternion.identity, GameObject.Find("Bubble").transform);
        obj.GetComponent<Bubble>().applyForce = true;
    }

    public void TryToGetItems(float percentile, Vector3 bubblePos)
    {
        if (Random.Range(0, 100) <= percentile && itemCooldownTimer <= 0)
        {
            SpawnItem(Random.Range(0, items.Count), bubblePos);
            itemCooldownTimer = 3f;
        }
    }

    private void SpawnItem(int itemNumber, Vector3 bubblePos)
    {
        GameObject obj = Instantiate(items[itemNumber], bubblePos, Quaternion.identity);
        obj.name = items[itemNumber].name;
    }
}
