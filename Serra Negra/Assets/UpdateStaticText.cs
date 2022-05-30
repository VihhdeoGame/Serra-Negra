using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateStaticText : MonoBehaviour
{
    TMP_Text textField;
    [SerializeField]
    string textPt;
    [SerializeField]
    string textEn;
    GameLanguageType currentLanguage;
    private void Start()
    {
        textField = GetComponent<TMP_Text>(); 
        UpdateText();
    }
    private void Update()
    {
        if(GameManager.GameSettings.GameLanguage != currentLanguage) UpdateText();
    }
    private void UpdateText()
    {
        if(GameManager.GameSettings.GameLanguage == GameLanguageType.PT_BR) textField.text = textPt;
        if(GameManager.GameSettings.GameLanguage == GameLanguageType.EN_US) textField.text = textEn;
        currentLanguage = GameManager.GameSettings.GameLanguage;
    }
}
