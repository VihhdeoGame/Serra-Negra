using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSettings : MonoBehaviour
{
    [SerializeField]
    Slider masterVolume;
    [SerializeField]
    Slider musicVolume;
    [SerializeField]
    Slider sfxVolume;
    [SerializeField]
    TMP_Dropdown languageDropdown;
    [SerializeField]
    TMP_Dropdown textSpeedDropdown;
    [SerializeField]
    Toggle autoToggle;
    private void Start()
    {
        masterVolume.SetValueWithoutNotify(GameManager.AudioSettings.MasterVolume);
        musicVolume.SetValueWithoutNotify(GameManager.AudioSettings.MusicVolume);
        sfxVolume.SetValueWithoutNotify(GameManager.AudioSettings.SfxVolume);
        languageDropdown.value = (int)GameManager.GameSettings.GameLanguage;
        textSpeedDropdown.value = (int)GameManager.TextSettings.TextSpeed;
        autoToggle.isOn = GameManager.TextSettings.Auto;
    }
    public void Auto(bool _value)
    {
        GameManager.TextSettings.Auto = _value;
    }

    public void ChangeMasterVolume(float _value)
    {
        GameManager.AudioSettings.MasterVolume = _value;
    }
    public void ChangeMusicVolume(float _value)
    {
        GameManager.AudioSettings.MusicVolume = _value;
    }
    public void ChangeSFXVolume(float _value)
    {
        GameManager.AudioSettings.SfxVolume = _value;
    }
    public void ChangeGameLanguage(int _value)
    {
        switch (_value)
        {
            case 0:
                GameManager.GameSettings.GameLanguage = GameLanguageType.PT_BR;
            break;

            case 1:
                GameManager.GameSettings.GameLanguage = GameLanguageType.EN_US;
            break;

            default:
                GameManager.GameSettings.GameLanguage = GameLanguageType.PT_BR;
            break;
        }
    }
    public void ChangeTextSpeed(int _value)
    {
        switch (_value)
        {
            case 0:
                GameManager.TextSettings.TextSpeed = TextSpeed.Slow;
            break;

            case 1:
                GameManager.TextSettings.TextSpeed = TextSpeed.Normal;
            break;

            case 2:
                GameManager.TextSettings.TextSpeed = TextSpeed.Fast;
            break;

            default:
                GameManager.TextSettings.TextSpeed = TextSpeed.Normal;
            break;
        }
    }
    /*public void SetQuality(int _value)
    {
        switch (_value)
        {
            case 0:
                GameManager.GameSettings.GameQuality = QualityType.Low;
            break;

            case 1:
                GameManager.GameSettings.GameQuality = QualityType.Medium;
            break;
            
            case 2:
                GameManager.GameSettings.GameQuality = QualityType.High;
            break;
            
            case 3:
                GameManager.GameSettings.GameQuality = QualityType.Very_High;
            break;
            
            case 4:
                GameManager.GameSettings.GameQuality = QualityType.Ultra;
            break;

            default:
                GameManager.GameSettings.GameQuality = QualityType.Medium;
            break;
        }
    }*/
}
