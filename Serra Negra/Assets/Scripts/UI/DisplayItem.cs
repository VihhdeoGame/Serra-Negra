using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class DisplayItem : MonoBehaviour
{
    public Item item;
    TMP_Text amoutText;
    TMP_Text nameText;
    TMP_Text descriptionText;
    Image imageSprite;
    private void OnEnable()
    {
        imageSprite = GetComponent<Image>();
        imageSprite.sprite = item.sprite;
        amoutText = GameObject.FindGameObjectWithTag("IADisplay").GetComponent<TMP_Text>();       
        nameText = GameObject.FindGameObjectWithTag("INDisplay").GetComponent<TMP_Text>();       
        descriptionText = GameObject.FindGameObjectWithTag("IDDisplay").GetComponent<TMP_Text>();       
    }
    private void OnDisable()
    {
        amoutText.text = "";
        nameText.text = "";
        descriptionText.text = "";        
    }
    public void ShowItem()
    {
        amoutText.text = item.amount.ToString();
        if(GameManager.GameSettings.GameLanguage == GameLanguageType.PT_BR)
        {
            nameText.text = item.name_PT;
            descriptionText.text = item.description_PT;
        }
        if(GameManager.GameSettings.GameLanguage == GameLanguageType.EN_US)
        {
            nameText.text = item.name_EN;
            descriptionText.text = item.description_PT;
        } 
    }

}
