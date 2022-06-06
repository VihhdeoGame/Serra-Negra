using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangePauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryPanel;
    [SerializeField]
    GameObject settingsPanel;
    [SerializeField]
    TMP_Text buttonText;
    string textPt = "Configurações";
    string textEn = "Settings";
    GameLanguageType currentLanguage;
    private void Start()
    {
        UpdateText();
    }
    private void Update()
    {
        if(GameManager.GameSettings.GameLanguage != currentLanguage) UpdateText();
    }
    private void UpdateText()
    {
        if(GameManager.GameSettings.GameLanguage == GameLanguageType.PT_BR) buttonText.text = textPt;
        if(GameManager.GameSettings.GameLanguage == GameLanguageType.EN_US) buttonText.text = textEn;
        currentLanguage = GameManager.GameSettings.GameLanguage;
    }
    public void ChangeMenu()
    {
        if(inventoryPanel.activeSelf)
        {
            settingsPanel.SetActive(true);
            inventoryPanel.SetActive(false);
            if(GameManager.GameSettings.GameLanguage == GameLanguageType.PT_BR)textPt = "Inventário";
            if(GameManager.GameSettings.GameLanguage == GameLanguageType.EN_US)textEn = "Inventory";
            UpdateText();
        }
        else if(settingsPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            settingsPanel.SetActive(false);
            if(GameManager.GameSettings.GameLanguage == GameLanguageType.PT_BR)textPt = "Configurações";
            if(GameManager.GameSettings.GameLanguage == GameLanguageType.EN_US)textEn = "Settings";
            UpdateText();
        }
    }    
}
