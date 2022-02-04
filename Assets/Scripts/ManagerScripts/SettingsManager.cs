using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public void ChangeQualitySettings(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
