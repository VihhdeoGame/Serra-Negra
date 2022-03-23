using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettingsData", menuName = "ScriptableObjects/AudioSettings")]
public class AudioSettingsScriptableObject : ScriptableObject
{
    [SerializeField,Range(0.0001f,1f)]
    private float masterVolume;
    public float MasterVolume{get {return masterVolume;} set {this.masterVolume = value;}}
    [SerializeField,Range(0.0001f,1f)]
    private float musicVolume;
    public float MusicVolume{get {return musicVolume;} set {this.musicVolume = value;}}
    [SerializeField,Range(0.0001f,1f)]
    private float sfxVolume;
    public float SfxVolume{get {return sfxVolume;} set {this.sfxVolume = value;}}
}
