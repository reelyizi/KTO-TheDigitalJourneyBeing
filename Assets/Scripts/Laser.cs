using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public void PlayLaser() => AudioManager.instance.AudioPlay("Laser");
}
