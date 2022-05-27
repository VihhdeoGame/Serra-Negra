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
    TMP_Dropdown fontSizeDropdown;
    private void Start()
    {
        masterVolume.value = GameManager.AudioSettings.MasterVolume;
        musicVolume.value = GameManager.AudioSettings.MusicVolume;
        sfxVolume.value = GameManager.AudioSettings.SfxVolume;
        languageDropdown.value = (int)GameManager.GameSettings.GameLanguage;
        textSpeedDropdown.value = (int)GameManager.TextSettings.TextSpeed;
        fontSizeDropdown.value = (int)GameManager.TextSettings.FontSize;
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
    public void ChangeFontSize(int _value)
    {
        switch (_value)
        {
            case 0:
                GameManager.TextSettings.FontSize = FontSize.Small;
            break;

            case 1:
                GameManager.TextSettings.FontSize = FontSize.Medium;
            break;

            case 2:
                GameManager.TextSettings.FontSize = FontSize.Large;
            break;

            default:
                GameManager.TextSettings.FontSize = FontSize.Medium;
            break;
        }
    }
}
