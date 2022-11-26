using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider Sound;
    public Slider Music;

    private float SliderSoundValue;

    public Toggle Mute;

    // Sound Lists
    public AudioMixer Mixer;
    
    const string Mixer_Sound = "Sound";
    const string Mixer_Music = "Music";
    const string Mixer_SFX = "SFX";

    private void Awake()
    {
        Sound.onValueChanged.AddListener(ChangeSoundSlider);
        Music.onValueChanged.AddListener(ChangeMusicSlider);
    }

    private void Start()
    {
        // Load Date
        Sound.value = PlayerPrefs.GetFloat("SoundValue");
        Music.value = PlayerPrefs.GetFloat("MusicValue");
    }

    // Start is called before the first frame update
    public void ChangeSoundSlider(float value)
    {
        Mixer.SetFloat(Mixer_Sound, MathF.Log10(value)* 20);
        PlayerPrefs.SetFloat("SoundValue",value);
    }
    public void ChangeMusicSlider(float value)
    {
        Mixer.SetFloat(Mixer_Music, MathF.Log10(value)* 20);
        PlayerPrefs.SetFloat("MusicValue",value);
    }

    public void MuteButtonToogle(bool tog)
    {
        if (Mute.isOn)
        {
            Sound.value = 0;
            Music.value = 0;
        }
        else if(!Mute.isOn)
        {
            Sound.value = PlayerPrefs.GetFloat("SoundValue");
            Music.value = PlayerPrefs.GetFloat("MusicValue");
        }
    }
}
