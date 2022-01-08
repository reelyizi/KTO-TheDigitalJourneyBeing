using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] MSCsounds;
    public Sound[] SFXsounds;

    public static AudioManager instance;
    [HideInInspector] public string currentMSC;
    private string preMsc;

    private void Awake()
    {
        foreach (Sound sound in MSCsounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = (sound.defaultVolume * PlayerPrefs.GetFloat("GeneralVolume") * PlayerPrefs.GetFloat("MSCVolume"));
            sound.source.pitch = sound.pitch;

            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in SFXsounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = (sound.defaultVolume * PlayerPrefs.GetFloat("GeneralVolume") * PlayerPrefs.GetFloat("SFXVolume"));
            sound.source.pitch = sound.pitch;

            sound.source.loop = sound.loop;
        }

        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }
    }

    public void SetMSCVolume()
    {
        AudioSource[] audioSource = GetComponents<AudioSource>();

        foreach (Sound sound in MSCsounds)
        {
            for (int i = 0; i < audioSource.Length; i++)
            {
                if (audioSource[i].clip.name == sound.clip.name)
                    audioSource[i].volume = (sound.defaultVolume * PlayerPrefs.GetFloat("GeneralVolume") * PlayerPrefs.GetFloat("MSCVolume"));
            }
        }
    }

    public void SetSFXVolume()
    {
        AudioSource[] audioSource = GetComponents<AudioSource>();
        foreach (Sound sound in SFXsounds)
        {
            for (int i = 0; i < audioSource.Length; i++)
            {
                if (audioSource[i].clip.name == sound.clip.name)
                    audioSource[i].volume = (sound.defaultVolume * PlayerPrefs.GetFloat("GeneralVolume") * PlayerPrefs.GetFloat("SFXVolume"));
            }
        }
    }

    public void StartMusic()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            AudioPlay("Main_Menu_01");
        else
        {
            //currentMSC = "LevelTheme0" + UnityEngine.Random.Range(0, 4);
            //Debug.Log(currentMSC);
            AudioPlay(RandomLevelMusic());
        }           
    }

    /// <summary>
    /// It will not return same music played before
    /// </summary>
    /// <returns></returns>
    public string RandomLevelMusic()
    {
        //Debug.Log(preMsc);
        string msc = "LevelTheme0" + UnityEngine.Random.Range(0, 4);
        //Debug.Log(msc);
        Debug.Log(currentMSC);
        
        //preMsc = msc;
        if (currentMSC == msc)
        {
            Debug.Log("res");
            RandomLevelMusic();
        }            
        else
        {
            currentMSC = ""+msc;
            //Debug.Log(currentMSC);
        }
        //Debug.Log(preMsc);
        return currentMSC;
    }

    public void AudioPlay(string name)
    {
        if(Array.Exists(SFXsounds, element => element.name == name))
            Array.Find(SFXsounds, sound => sound.name == name).source.Play();
        if (Array.Exists(MSCsounds, element => element.name == name))
            Array.Find(MSCsounds, sound => sound.name == name).source.Play();
    }
    public void AudioStop(string name)
    {
        if (Array.Exists(SFXsounds, element => element.name == name))
            Array.Find(SFXsounds, sound => sound.name == name).source.Play();
        if (Array.Exists(MSCsounds, element => element.name == name))
            Array.Find(MSCsounds, sound => sound.name == name).source.Play();
    }
}
