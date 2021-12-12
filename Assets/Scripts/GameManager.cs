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
        if(_instance == null)
        {
            _instance = this;
        }
    }
    public static int score=0;
    public static float timerControl = 0;
    public float levelTime = float.MaxValue;
    private float startTime;
    public TextMeshProUGUI text,scoreText;
    public GameObject totalBubble;
    [Range(1, 999)] public float maxSpawnRate;
    [Range(1, 999)] public float minSpawnRate;

    public Transform A, B;
    public GameObject bigBubble;
    float timer;
    void Start()
    {
        startTime = Time.time;
        timer = Random.Range(minSpawnRate, maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        timerControl = Time.time - startTime;
        //levelTime = (int)Time.time / 60;
        text.text = ((int)timerControl).ToString();
        scoreText.text = score.ToString();
        if(totalBubble.transform.childCount == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = Random.Range(minSpawnRate, maxSpawnRate);
            GameObject obj = Instantiate(bigBubble, new Vector2(Random.Range(A.position.x, B.position.x), A.position.y), Quaternion.identity, GameObject.Find("Bubble").transform);
            obj.GetComponent<Bubble>().applyForce = true;
        }
    }
}
