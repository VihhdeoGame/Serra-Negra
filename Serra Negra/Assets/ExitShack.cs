using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShack : MonoBehaviour
{
    GenericCanvas shackCanvas;
    private void OnEnable() 
    {
        shackCanvas = FindObjectOfType<GenericCanvas>();       
    }
    public void Exit()
    {
        StopAllCoroutines();
        StartCoroutine(EShack());   
        IEnumerator EShack()
        {
            FadeManager.Fade.FadeIn();
            yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
            FindObjectOfType<CursorController>().DisableCursor();
            FindObjectOfType<CursorController>().is2D = false;
            shackCanvas.Hide();
            FadeManager.Fade.FadeOut();
        }   
    }
}
