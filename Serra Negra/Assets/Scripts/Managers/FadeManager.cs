using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    Trigger2DDialog dialog;
    private static FadeManager fadeManager;
    public static FadeManager Fade{ get{ return fadeManager; } }
    private Image fade;
    [SerializeField]
    private float waitTime;
    public float WaitTime{get {return waitTime;}} 
    private void Awake()
    {
        if(fadeManager != null && fadeManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            fadeManager = this;
        }
        dialog = GetComponent<Trigger2DDialog>();
    }
    private void Start() 
    {
        fade = GetComponent<Image>();
        FadeOut();
    }
    public void FadeOut()
    {
        fade.CrossFadeAlpha(0,waitTime, true);
    }
    public void FadeIn()
    {
        fade.CrossFadeAlpha(1,waitTime, true);
    }
}
