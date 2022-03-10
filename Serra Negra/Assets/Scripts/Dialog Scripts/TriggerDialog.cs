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
    private TextAsset dialog;
    [SerializeField]
    private TextMeshProUGUI textBox;
    [SerializeField]
    private TextMeshProUGUI nameBox;
    [SerializeField]
    private Image speakerSprite;
    private Dialogs dialogParse;
    private Object[] speakers;
    [SerializeField]
    private Item item;
    [SerializeField]
    private bool containsItem;
    [SerializeField]
    private int itemKey;
    InputManager playerInput;
    float gridSize = 3f;
    private void Start() 
    {
        playerInput = InputManager.PlayerInput;
        speakers = Resources.LoadAll("Speakers", typeof(Sprite));
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
            speakerSprite.sprite = (Sprite)speakers[_dialog[j].id];
            nameBox.text = _dialog[j].name;
            for (int k = 0; k < sentenses.Length; k++)
            {
                textBox.text = "";
                for(int i = 0; i < sentenses[k].Length;i++)
                {
                    textBox.text += sentenses[k][i];
                    yield return null;
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
    }

    public void CheckDialog()
    {
        if(!InventoryManager.Inventory.GetInventory().items.ContainsKey(itemKey))
            if(!display.activeSelf)
            {
                display.SetActive(true);
                crosshair.SetActive(false);
                DisplayDialog(dialog.text);
            }
    } 

    void GiveItem(int key,Item _item)
    {
        InventoryManager.Inventory.AddItemtoInventory(key,_item.amount, _item.name,_item.isStorable, _item.description,_item.sprite);
        if(_item.isStorable)
            Destroy(this.gameObject); 
    }
}
