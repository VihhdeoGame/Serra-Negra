using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TriggerDialog : MonoBehaviour
{
    [SerializeField]
    protected int itemKey;
    [SerializeField]
    protected TextAsset[] dialogs_PT;
    [SerializeField]
    protected TextAsset[] dialogs_EN;
    [SerializeField,HideInInspector]
    protected bool containsItem;
    [SerializeField,HideInInspector]
    protected Item item;
    [HideInInspector]
    public bool requiredCheck;
    [SerializeField,HideInInspector]
    protected int[] requiredItemKey;
    [SerializeField,HideInInspector]
    protected int[] requiredAmount;
    protected int arrayCount = 0;
    protected int[] dummy;
    protected Dialogs dialogParse;
    protected Object[] speakers;
    protected Object[] sfxs;
    protected Object[] musics;
    protected AudioSource musicPlayer;
    protected AudioSource sfxPlayer;
    protected InputManager playerInput;
    protected DialogCanvas dialogCanvas;
    protected Animator animator;
    [SerializeField]
    protected bool skipAnim;
    
    [SerializeField]
    protected UnityEvent runAfterClose;
    [SerializeField]
    protected UnityEvent runAfterCheck;

    protected virtual void Start()
    {
        musicPlayer = FindObjectOfType<MusicManager>().GetComponent<AudioSource>();
        dialogCanvas = FindObjectOfType<DialogCanvas>(true);
        animator = dialogCanvas.gameObject.GetComponent<Animator>();
        playerInput = InputManager.PlayerInput;
        speakers = Resources.LoadAll("Speakers", typeof(Sprite));
        sfxs = Resources.LoadAll("Audio/SFX", typeof(AudioClip));
        musics = Resources.LoadAll("Audio/Music", typeof(AudioClip));
    }

     protected void DisplayDialog(string _dialog)
    {
        dialogParse = JsonUtility.FromJson<Dialogs>(_dialog);
        StopAllCoroutines();
        StartCoroutine(TypeSentense(dialogParse.dialogs));
    }
    IEnumerator TypeSentense(Dialog[] _dialog)
    {
        for (int j = 0; j < _dialog.Length; j++)
        {
            dialogCanvas.NameBox.text = "";
            string[]sentenses = _dialog[j].sentenses.Split('>');
            dialogCanvas.SpeakerSprite.sprite = (Sprite)speakers[_dialog[j].spriteId];
            dialogCanvas.NameBox.text = _dialog[j].name;
            dialogCanvas.TextBox.text = "";
            if(j == 0) yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            int musicIndex = 0;
            int sfxIndex = 0;
            for (int k = 0; k < sentenses.Length; k++)
            {
                dialogCanvas.TextBox.text = "";
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
                    dialogCanvas.TextBox.text += sentenses[k][i];
                    yield return new WaitForSeconds(GameManager.TextSettings.Speed);
                }
                Debug.Log("Waiting for Interaction" + playerInput);
                if(GameManager.TextSettings.Auto) yield return new WaitForSeconds(GameManager.TextSettings.Speed * 10f);
                else yield return new WaitUntil(()=>playerInput.GetInteraction());
            }
        }
        animator.SetTrigger("Exit");
        if(!skipAnim)yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        dialogCanvas.Canvas.SetActive(false);
        RunAfter();
        UpdateDisplay(true);
        if(containsItem && !requiredCheck)
        {
            GiveItem(itemKey,item);
        }
        else if(containsItem && requiredCheck && CheckFlag())
        {
            GiveItem(itemKey,item);            
        }
        if(CheckFlag())
        {
            FinalInteraction();            
        }
    }

    private void RunAfter()
    {
        runAfterClose.Invoke();        
    }

    public void CheckDialog(int _id)
    {
        if(!InventoryManager.Inventory.GetInventory().items.ContainsKey(itemKey))
        {
            if(!dialogCanvas.Canvas.activeSelf)
            {
                dialogCanvas.Canvas.SetActive(true);
                UpdateDisplay(false);
                if(GameManager.GameSettings.GameLanguage == GameLanguageType.PT_BR){DisplayDialog(dialogs_PT[_id].text);}
                if(GameManager.GameSettings.GameLanguage == GameLanguageType.EN_US){DisplayDialog(dialogs_EN[_id].text);}
            }
        }
        else if(InventoryManager.Inventory.GetInventory().items.ContainsKey(itemKey) && item.isStorable)
            GiveItem(itemKey,item);
        else if(InventoryManager.Inventory.GetInventory().items.ContainsKey(itemKey) && !item.isStorable)
            RunAfter();

    }
    protected void GiveItem(int key,Item _item)
    {
        InventoryManager.Inventory.AddItemtoInventory(key,_item.amount, _item.name_PT,_item.name_EN,_item.isStorable, _item.description_PT,_item.description_EN,_item.sprite);
        if(_item.isStorable)
            Destroy(this.gameObject); 
    }
     
    public bool CheckFlag()
    {
        for (int i = 0; i < requiredItemKey.Length; i++)
        {
            if(InventoryManager.Inventory.GetInventory().items.ContainsKey(requiredItemKey[i]))
            {
                Item _item = InventoryManager.Inventory.GetInventory().items[requiredItemKey[i]];
                if(_item.amount < requiredAmount[i])
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    protected virtual void UpdateDisplay(bool active)
    {

    }
    protected virtual void FinalInteraction()
    {
        runAfterCheck.Invoke();        
    }
}

