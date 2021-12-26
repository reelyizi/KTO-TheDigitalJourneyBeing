using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDuration : MonoBehaviour
{
    [SerializeField] private float itemDuration;
    private float timeElapsed = 0;
    
    void Update()
    {
        timeElapsed += Time.deltaTime;
        GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, new Color(255, 255, 255, 1 - (timeElapsed / itemDuration)), 1);
        if (timeElapsed >= itemDuration)
            Destroy(this.gameObject);
    }
}
