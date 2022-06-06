using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateDropDownText : MonoBehaviour
{
    TMP_Dropdown dropdown;
    [SerializeField]
    string[] textPt;
    [SerializeField]
    string[] textEn;
    GameLanguageType currentLanguage;
    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        UpdateText();
    }
    private void Update()
    {
        if(GameManager.GameSettings.GameLanguage != currentLanguage) UpdateText();
    }
    private void UpdateText()
    {
        if(GameManager.GameSettings.GameLanguage == GameLanguageType.PT_BR)
            for(int i = 0; i < dropdown.options.Count; i++)
            {
                dropdown.options[i].text = textPt[i];   
            }
        if(GameManager.GameSettings.GameLanguage == GameLanguageType.EN_US)
            for(int i = 0; i < dropdown.options.Count; i++)
            {
                dropdown.options[i].text = textEn[i];   
            }
        dropdown.captionText.text = dropdown.options[(int)GameManager.TextSettings.TextSpeed].text;
        currentLanguage = GameManager.GameSettings.GameLanguage;
    }
}
