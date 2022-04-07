using System.Collections;
using UnityEngine;

public class MoveToSomewhere : MonoBehaviour
{
    [SerializeField]
    MainGameCanvas canvas;
    GenericCanvas parent;
    private void OnEnable()
    {
        parent = gameObject.GetComponentInParent<GenericCanvas>();
    }

    public void Move(int _canvas)
    {
        StopAllCoroutines();
        StartCoroutine(StartMoving(_canvas));
    }
    IEnumerator StartMoving(int _canvas)
    {
        Debug.Log("mova caralho");
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        parent.Hide();
        canvas.Canvases[_canvas].Show();
        FadeManager.Fade.FadeOut();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
    }

}
