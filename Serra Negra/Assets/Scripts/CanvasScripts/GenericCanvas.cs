using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Trigger2DDialog))]
public class GenericCanvas : MonoBehaviour
{
    private Trigger2DDialog dialog;
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
        dialog = GetComponent<Trigger2DDialog>();
        dialog.CheckDialog(0);                
    }
}
