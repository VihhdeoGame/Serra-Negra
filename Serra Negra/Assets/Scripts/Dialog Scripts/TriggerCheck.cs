using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    Trigger3DDialog dialog;
    private void Awake()
    {
        dialog = GetComponent<Trigger3DDialog>();        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            dialog.CheckDialog(0);
        }        
    }
}
