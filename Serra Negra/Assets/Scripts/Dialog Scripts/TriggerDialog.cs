using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TriggerDialog : MonoBehaviour
{
    [SerializeField]
    private int itemKey;
    
    [SerializeField]
    private TextAsset[] dialogs_PT;
    [SerializeField]
    private TextAsset[] dialogs_EN;
    
    
    [SerializeField]
    private bool containsItem;
    [SerializeField]
    private Item item;

    public bool requiredCheck;
    private int requiredItemKey;
    private int requiredAmount;

#if UNITY_EDITOR
    [CustomEditor(typeof(TriggerDialog))]
    public class TriggerDialogEditor : Editor {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            TriggerDialog triggerDialog = (TriggerDialog)target;
            if(triggerDialog.containsItem)
            {

            }
            if(triggerDialog.requiredCheck)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Required Item ID",GUILayout.MaxWidth(100));
                triggerDialog.requiredItemKey = EditorGUILayout.IntField(triggerDialog.requiredItemKey);
                EditorGUILayout.LabelField("Required Item Amount",GUILayout.MaxWidth(130));
                triggerDialog.requiredAmount = EditorGUILayout.IntField(triggerDialog.requiredAmount);
                EditorGUILayout.EndHorizontal();
            }       
        }
    }
#endif
    

    private GameObject crosshair;
    private Dialogs dialogParse;
    private Object[] speakers;
    private Object[] sfxs;
    private Object[] musics;
    private AudioSource musicPlayer;
    private AudioSource sfxPlayer;
    InputManager playerInput;
    DialogCanvas dialogCanvas;
    private void Start() 
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        sfxPlayer = FindObjectOfType<PlayerController>().SfxPlayer;
        musicPlayer = FindObjectOfType<MusicManager>().GetComponent<AudioSource>();
        dialogCanvas = FindObjectOfType<DialogCanvas>(true);
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
            dialogCanvas.NameBox.text = "";
            string[]sentenses = _dialog[j].sentenses.Split('>');
            dialogCanvas.SpeakerSprite.sprite = (Sprite)speakers[_dialog[j].spriteId];
            dialogCanvas.NameBox.text = _dialog[j].name;
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
                yield return new WaitUntil(()=>playerInput.GetInteraction());
            }
        }
        dialogCanvas.Canvas.SetActive(false);
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
            if(!dialogCanvas.Canvas.activeSelf)
            {
                dialogCanvas.Canvas.SetActive(true);
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
