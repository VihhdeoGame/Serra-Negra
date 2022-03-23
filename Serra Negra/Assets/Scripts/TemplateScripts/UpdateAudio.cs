using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UpdateAudio : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    const string MASTER_VOLUME = "MasterVolume";
    const string MUSIC_VOLUME = "MusicVolume";
    const string SFX_VOLUME = "SFXVolume";
    private void Update()
    {
        mixer.SetFloat(MASTER_VOLUME, Mathf.Log10(GameManager.AudioSettings.MasterVolume) * 20);                
        mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(GameManager.AudioSettings.MusicVolume) * 20);                
        mixer.SetFloat(SFX_VOLUME, Mathf.Log10(GameManager.AudioSettings.SfxVolume) * 20);                
    } 
}
