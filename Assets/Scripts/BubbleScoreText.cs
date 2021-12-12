using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleScoreText : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    Color bigColor = new Color(0.94f, 0.94f, 0.94f, 255);
    Color midColor = new Color(0.91f, 0.51f, 0.07f, 255);
    Color smallColor = new Color(0.69f, 0.76f, 0.27f, 255);
    Color smallestColor = new Color(0.45f, 0.92f, 0.62f, 255);
    void Update()
    {
        lifeTime -= Time.deltaTime;
        transform.position += Vector3.up * speed * Time.deltaTime;        
        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetText(int value)
    {               
        switch(value)
        {
            case 400:
                GetComponent<TextMeshProUGUI>().color = bigColor;
                break;
            case 200:
                GetComponent<TextMeshProUGUI>().color = midColor;
                break;
            case 100:
                GetComponent<TextMeshProUGUI>().color = smallColor;
                break;
            case 50:
                GetComponent<TextMeshProUGUI>().color = smallestColor;
                break;
        }
        GetComponent<TextMeshProUGUI>().text = "+"+value.ToString();
    }
}
