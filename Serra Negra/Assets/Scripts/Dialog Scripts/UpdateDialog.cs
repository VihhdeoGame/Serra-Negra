using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDialog : MonoBehaviour
{
    GenericCanvas parent;
    private void Awake()
    {
        parent = GetComponentInParent<GenericCanvas>();        
    }
    public void UpdateDialogTo(Trigger2DDialog _newDialog)
    {
        parent.Dialog = _newDialog;
    }
}
