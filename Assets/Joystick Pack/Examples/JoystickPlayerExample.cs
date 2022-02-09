using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;

    public void FixedUpdate()
    {
        if(variableJoystick.Horizontal!=0)
        {
            GameManager._instance.isWalkForTutorial=true;
        }
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        transform.position+=direction * speed * Time.fixedDeltaTime;
    }
}