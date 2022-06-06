using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOldDialog : MonoBehaviour
{
    [SerializeField]
    Trigger2DDialog dialog;
    private void OnEnable()
    {
        dialog.RunAfterClose = null;       
    }
}
