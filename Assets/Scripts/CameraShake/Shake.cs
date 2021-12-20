using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public static bool start=false;
    public AnimationCurve animationCurve;
    public float duration=1f;

    void Update()
    {
        if(start)
        {
            start=false;
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking()
    {
        Vector3 startPos=transform.position;
        float elapsedTime=0f;

        while(elapsedTime<duration)
        {
            elapsedTime+=Time.deltaTime;
            float strength=animationCurve.Evaluate(elapsedTime/duration);
            transform.position=startPos+Random.insideUnitSphere*strength;
            yield return null;
        }
        transform.position=startPos;
    }
}
