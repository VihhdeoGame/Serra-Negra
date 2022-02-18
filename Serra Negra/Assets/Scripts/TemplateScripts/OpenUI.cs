using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenUI : MonoBehaviour
{
    [SerializeField]
    private GameObject display;
    [SerializeField]
    private TextAsset dialog;
    [SerializeField]
    private TextMeshProUGUI textBox;
    private void OnMouseDown()
    {
        if(!display.activeSelf)
        {
            display.SetActive(true);
            TriggerDialog(dialog);
        }    
    }
    private void TriggerDialog(TextAsset _dialog)
    {
        string[]sentenses = _dialog.text.Split('>');
        StopAllCoroutines();
        StartCoroutine(TypeSentense(sentenses));
    }

    IEnumerator TypeSentense(string[] sentenses)
    {
        for (int j = 0; j < sentenses.Length; j++)
        {
            textBox.text = "";
            for(int i = 0; i < sentenses[j].Length;i++)
            {
                textBox.text += sentenses[j][i];
                yield return null;
            }
            yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
        }
        display.SetActive(false);
    }
}
