using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] MSCsounds;
    public Sound[] SFXsounds;

    public static AudioManager instance;

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

    private void Start()
    {
        AudioManager.instance.AudioPlay("LevelTheme");
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
