using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

            sound.source.loop = sound.loop;
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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
        Array.Find(sounds, sound => sound.name == name).source.Play();
    }
    public void AudioStop(string name)
    {
        Array.Find(sounds, sound => sound.name == name).source.Stop();
    }
}
