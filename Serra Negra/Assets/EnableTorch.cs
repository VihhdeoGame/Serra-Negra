using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTorch : MonoBehaviour
{
    bool holdingTorch;
    DialogCanvas dialogCanvas;
    CursorController cursorController;
    Trigger3DDialog dialog;
    [SerializeField]
    GameObject torch;
    private void Start()
    {
        dialog = GetComponent<Trigger3DDialog>();
        cursorController = FindObjectOfType<CursorController>();
        dialogCanvas = FindObjectOfType<DialogCanvas>(true);
    }
    private void Update()
    {
        if(!holdingTorch && !dialogCanvas.Canvas.activeSelf && !cursorController.is2D && dialog.CheckFlag())
        {
            StopAllCoroutines();
            StartCoroutine(HoldTorch());
            holdingTorch = true;
        }
    }
    IEnumerator HoldTorch()
    {
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        torch.SetActive(true);
        FadeManager.Fade.FadeOut();
        dialog.CheckDialog(0);
    }
}
