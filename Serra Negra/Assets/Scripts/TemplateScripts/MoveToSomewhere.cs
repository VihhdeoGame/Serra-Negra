using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToSomewhere : MonoBehaviour
{
    [SerializeField]
    private Image fade;
    [SerializeField]
    private SpriteRenderer background;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private Sprite[] backgounds;
    [SerializeField]
    private int backgroundId;
    private void Start() 
    {
        FadeOut();
    }
    private void OnMouseDown() 
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(backgroundId));
    }
    private void FadeOut()
    {
        fade.CrossFadeAlpha(0,waitTime, false);
    }
    private void FadeIn()
    {
        fade.CrossFadeAlpha(1,waitTime, false);
    }

    IEnumerator MoveTo(int _backgroundId)
    {
        FadeIn();
        yield return new WaitForSeconds(waitTime);
        background.sprite = backgounds[_backgroundId];
        FadeOut();
    }
}
