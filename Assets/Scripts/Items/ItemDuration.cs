using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDuration : MonoBehaviour
{
    [SerializeField] private float itemDuration;
    [SerializeField] private float speedMultiplier = 1f;
    private float timeElapsed = 0;
    private float timeHolder = 0;
    private bool alphaFlag;
    private bool speedStoper;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        timeHolder += Time.deltaTime;
        Debug.Log(timeHolder);
        if (itemDuration - timeHolder < 3 && !speedStoper)
        { speedMultiplier *= 2.5f; speedStoper = !speedStoper; }
        if (!alphaFlag)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(255, 255, 255, 1 - ((timeElapsed / itemDuration) * speedMultiplier)), 1 + ((timeHolder / itemDuration) * speedMultiplier));
            if (spriteRenderer.color.a <= 0)
            { alphaFlag = !alphaFlag; timeElapsed = 0; }
        }
        else
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(255, 255, 255, ((timeElapsed / itemDuration) * speedMultiplier)), 1 + ((timeHolder / itemDuration) * speedMultiplier));
            if (spriteRenderer.color.a >= 1)
            { alphaFlag = !alphaFlag; timeElapsed = 0; }
        }
        if (timeHolder >= itemDuration)
            Destroy(this.gameObject);
    }
}
