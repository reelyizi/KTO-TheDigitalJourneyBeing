using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightSettings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lightText;
    [SerializeField] private List<GameObject> lights;
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Lights"))
            PlayerPrefs.SetString("Lights", "ON");

        if(PlayerPrefs.GetString("Lights") == "OFF")
        {
            lightText.text = "OFF";
            foreach (GameObject item in lights)
            {
                item.SetActive(false);
            }
        }
    }
    public void SetLightsEffects()
    {
        if(PlayerPrefs.GetString("Lights") == "ON")
        {
            lightText.text = "OFF";
            PlayerPrefs.SetString("Lights", "OFF");
            foreach (GameObject item in lights)
            {
                item.SetActive(false);
            }
        }
        else
        {
            lightText.text = "ON";
            PlayerPrefs.SetString("Lights", "ON");
            foreach (GameObject item in lights)
            {
                item.SetActive(true);
            }
        }        
    }
}
