using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShack : MonoBehaviour
{
    GenericCanvas shackCanvas;
    AudioSource sfxPlayer;
    [SerializeField]
    AudioClip transitionAudio;
    private void OnEnable() 
    {
        sfxPlayer = GameObject.FindGameObjectWithTag("SFXPlayer").GetComponent<AudioSource>();
        shackCanvas = FindObjectOfType<GenericCanvas>();       
    }
    public void Exit()
    {
        StopAllCoroutines();
        StartCoroutine(EShack());   
        IEnumerator EShack()
        {
            if(transitionAudio != null)sfxPlayer.PlayOneShot(transitionAudio);            
            FadeManager.Fade.FadeIn();
            yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
            FindObjectOfType<CursorController>().DisableCursor();
            FindObjectOfType<CursorController>().is2D = false;
            shackCanvas.Hide();
            FadeManager.Fade.FadeOut();
        }   
    }
}
