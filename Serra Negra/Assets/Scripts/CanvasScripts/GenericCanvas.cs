using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenericCanvas : MonoBehaviour
{
    [SerializeField]
    private Trigger2DDialog dialog;

    public Trigger2DDialog Dialog{get {return dialog;} set{dialog = value;}}
    [SerializeField]
    private MainGameCanvas mainGameCanvases;
    public void FirstInitialize(MainGameCanvas _canvases)
    {
        mainGameCanvases = _canvases;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        dialog.gameObject.SetActive(true);
        if(dialog.requiredCheck)
        {
            if(dialog.CheckFlag())
            {
                dialog.CheckDialog(1);
            }
            else
            {
                dialog.CheckDialog(0);
            }
        }
        else
        {
            dialog.CheckDialog(0);                            
        }                
    }
}
