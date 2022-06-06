using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
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
    }
    private void Start() 
    {
        fade = GetComponent<Image>();
        FadeOut();
    }
    public void FadeOut(float _waitTime = 0)
    {
        if(_waitTime == 0)fade.CrossFadeAlpha(0,waitTime, false);
        else fade.CrossFadeAlpha(0,_waitTime, false);
    }
    public void FadeIn(float _waitTime = 0)
    {
        if(_waitTime == 0)fade.CrossFadeAlpha(1,waitTime, false);
        else fade.CrossFadeAlpha(1,_waitTime, false);
    }
    public void BlackOut()
    {
        StopAllCoroutines();
        StartCoroutine(FlashDark());
    }
    IEnumerator FlashDark()
    {
        FadeIn(0.0001f);
        yield return new WaitForSeconds(waitTime);
        FadeOut();
    }
    public void GameOver()
    {
        StopAllCoroutines();
        StartCoroutine(MovetoGameOver());
        IEnumerator MovetoGameOver()
        {
            FadeIn(5);
            yield return new WaitForSeconds(5);
        }

    }
}
