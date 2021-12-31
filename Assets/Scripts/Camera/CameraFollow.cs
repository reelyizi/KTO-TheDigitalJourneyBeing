using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform zoneA, zoneB;
    private Vector3 offset;
    [SerializeField] private float smoothness = 1f;
    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if ((transform.position.x > zoneA.position.x && transform.position.x < zoneB.position.x)|| (target.position.x > zoneA.position.x && target.position.x < zoneB.position.x))
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smoothness);
        }
    }
}
