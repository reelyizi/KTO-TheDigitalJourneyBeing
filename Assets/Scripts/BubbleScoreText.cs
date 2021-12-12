using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleScoreText : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    Color startColor = new Color(255, 255, 255, 0);
    Color endColor = new Color(255, 255, 255, 1);
    void Update()
    {
        lifeTime -= Time.deltaTime;
        transform.position += Vector3.up * speed * Time.deltaTime;
        GetComponent<TextMeshProUGUI>().color = Color.Lerp(startColor, endColor, lifeTime * 10 / 100); 
        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetText(int value)
    {
        GetComponent<TextMeshProUGUI>().text = "+"+value.ToString();
    }
}
