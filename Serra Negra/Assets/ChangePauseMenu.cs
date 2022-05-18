using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryPanel;
    [SerializeField]
    GameObject settingsPanel;
    
    public void ChangeMenu()
    {
        if(inventoryPanel.activeSelf)
        {
            settingsPanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else if(settingsPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }
    }    
}
