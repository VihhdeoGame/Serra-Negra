using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpenUI : MonoBehaviour
{
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
    
    private void Start() 
    {
        speakers = Resources.LoadAll("Speakers", typeof(Sprite));
    }
    private void OnMouseDown()
    {
        if(!display.activeSelf)
        {
            display.SetActive(true);
            TriggerDialog(dialog.text);
        }    
    }
    
    private void TriggerDialog(string _dialog)
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
                yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
            }
        }
        display.SetActive(false);
    }
}
