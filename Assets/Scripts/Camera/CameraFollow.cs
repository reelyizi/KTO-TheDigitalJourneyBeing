using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    [SerializeField] private float smoothness = 1f;
    [SerializeField] private float deadZone = 5f;
    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if((Mathf.Abs(transform.position.x) - Mathf.Abs(target.position.x) > deadZone) || (Mathf.Abs(target.position.x) - Mathf.Abs(transform.position.x) > deadZone))
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smoothness);
        }
    }
}
