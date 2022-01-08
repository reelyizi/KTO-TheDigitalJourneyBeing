using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject generalVolume, sfxVolume, mscVolume;
    void Start()
    {
        if (!PlayerPrefs.HasKey("GeneralVolume"))
        {
            PlayerPrefs.SetFloat("GeneralVolume", generalVolume.GetComponent<Slider>().value);
        }
        else
        {
            generalVolume.GetComponent<Slider>().value = PlayerPrefs.GetFloat("GeneralVolume");
        }

        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", sfxVolume.GetComponent<Slider>().value);
        }            
        else
        {
            sfxVolume.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVolume");
        }

        if (!PlayerPrefs.HasKey("MSCVolume"))
        {
            PlayerPrefs.SetFloat("MSCVolume", mscVolume.GetComponent<Slider>().value);
        }            
        else
        {
            mscVolume.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MSCVolume");
        }
            

        GeneralVolumeListener();
        SFXVolumeListener();
        MSCVolumeListener();
    }

    public void GeneralVolumeListener()
    {
        PlayerPrefs.SetFloat("GeneralVolume", generalVolume.GetComponent<Slider>().value);
        AudioManager.instance.SetSFXVolume();
        AudioManager.instance.SetMSCVolume();
    }

    public void SFXVolumeListener()
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume.GetComponent<Slider>().value);
        AudioManager.instance.SetSFXVolume();
    }

    public void MSCVolumeListener()
    {
        PlayerPrefs.SetFloat("MSCVolume", mscVolume.GetComponent<Slider>().value);
        AudioManager.instance.SetMSCVolume();
    }
}
