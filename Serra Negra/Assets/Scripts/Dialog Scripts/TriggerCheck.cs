using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    TriggerDialog dialog;
    private void Awake()
    {
        dialog = GetComponent<TriggerDialog>();        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            dialog.CheckDialog(0);
        }        
    }
}
