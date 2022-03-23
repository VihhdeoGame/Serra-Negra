using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerDialog : MonoBehaviour
{
    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private GameObject display;
    [SerializeField]
    private TextAsset[] dialogs_PT;
    [SerializeField]
    private TextAsset[] dialogs_EN;
    [SerializeField]
    private TextMeshProUGUI textBox;
    [SerializeField]
    private TextMeshProUGUI nameBox;
    [SerializeField]
    private Image speakerSprite;
    private Dialogs dialogParse;
    private Object[] speakers;
    private Object[] sfxs;
    private Object[] musics;

    [SerializeField]
    private AudioSource musicPlayer;
    [SerializeField]
    private AudioSource sfxPlayer;
    [SerializeField]
    private Item item;
    [SerializeField]
    private bool containsItem;
    [SerializeField]
    private int itemKey;
    InputManager playerInput;
    
    [SerializeField]
    private int requiredItemKey;
    [SerializeField]
    private int requiredAmount;
    public bool requiredCheck;
    private void Start() 
    {
        playerInput = InputManager.PlayerInput;
        speakers = Resources.LoadAll("Speakers", typeof(Sprite));
        sfxs = Resources.LoadAll("Audio/SFX", typeof(AudioClip));
        musics = Resources.LoadAll("Audio/Music", typeof(AudioClip));
    }
    private void DisplayDialog(string _dialog)
    {
        dialogParse = JsonUtility.FromJson<Dialogs>(_dialog);
        StopAllCoroutines();
        StartCoroutine(TypeSentense(dialogParse.dialogs));
    }

    IEnumerator TypeSentense(Dialog[] _dialog)
    {
        for (int j = 0; j < _dialog.Length; j++)
        {
            nameBox.text = "";
            string[]sentenses = _dialog[j].sentenses.Split('>');
            speakerSprite.sprite = (Sprite)speakers[_dialog[j].spriteId];
            nameBox.text = _dialog[j].name;
            int musicIndex = 0;
            int sfxIndex = 0;
            for (int k = 0; k < sentenses.Length; k++)
            {
                textBox.text = "";
                for(int i = 0; i < sentenses[k].Length;i++)
                {
                    if(sentenses[k][i].Equals('#'))
                    {
                        musicPlayer.clip = (AudioClip)musics[_dialog[j].musicIds[musicIndex]];
                        musicPlayer.Play();
                        musicIndex++;
                        continue;
                    }
                    if(sentenses[k][i].Equals('*'))
                    {
                        sfxPlayer.clip = (AudioClip)sfxs[_dialog[j].sfxIds[sfxIndex]];
                        sfxPlayer.Play();
                        sfxIndex++;
                        continue;
                    }
                    textBox.text += sentenses[k][i];
                    yield return new WaitForSeconds(GameManager.TextSettings.Speed);
                }
                yield return new WaitUntil(()=>playerInput.GetInteraction());
            }
        }
        display.SetActive(false);
        crosshair.SetActive(true);
        if(containsItem)
        {
            GiveItem(itemKey,item);
        }
        if(CheckFlag())
        {
            OpenDoor();
        }
    }

    public void CheckDialog(int _id)
    {
        if(!InventoryManager.Inventory.GetInventory().items.ContainsKey(itemKey))
        {
            if(!display.activeSelf)
            {
                display.SetActive(true);
                crosshair.SetActive(false);
                if(GameManager.GameSettings.GameLanguage == GameLanguageType.PT_BR){DisplayDialog(dialogs_PT[_id].text);}
                if(GameManager.GameSettings.GameLanguage == GameLanguageType.EN_US){DisplayDialog(dialogs_EN[_id].text);}
            }
        }
        else if(InventoryManager.Inventory.GetInventory().items.ContainsKey(itemKey) && item.isStorable)
            GiveItem(itemKey,item);
    } 

    void GiveItem(int key,Item _item)
    {
        InventoryManager.Inventory.AddItemtoInventory(key,_item.amount, _item.name,_item.isStorable, _item.description,_item.sprite);
        if(_item.isStorable)
            Destroy(this.gameObject); 
    }
    public bool CheckFlag()
    {
        if(InventoryManager.Inventory.GetInventory().items.ContainsKey(requiredItemKey))
        {
            Item _item = InventoryManager.Inventory.GetInventory().items[requiredItemKey];
            return(_item.amount >= requiredAmount);
        }
        else
        {
            return false;
        }
    }
    
    public void OpenDoor()
    {
        Item _item = InventoryManager.Inventory.GetInventory().items[requiredItemKey];
        _item.amount -= requiredAmount;
        Destroy(this.gameObject);
    }
}
