using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToSomewhere : MonoBehaviour
{
    [SerializeField]
    bool check;
    [SerializeField]
    MainGameCanvas canvas;
    GenericCanvas parent;
    Trigger2DDialog dialog;
    private void OnEnable()
    {
        parent = gameObject.GetComponentInParent<GenericCanvas>();
    }
    public void Move(int _canvas)
    {
        if(!check)
        {
            StopAllCoroutines();
            StartCoroutine(StartMoving(_canvas));
        }
        else
        {
            dialog = GetComponent<Trigger2DDialog>();
            if(dialog.CheckFlag())
            {
                StopAllCoroutines();
                StartCoroutine(StartMoving(_canvas));
            }
            else
            {
                dialog.CheckDialog(0);
            }
        }
    }
    public void ChangeScene(int _scene)
    {
        StopAllCoroutines();
        StartCoroutine(UpdateScene(_scene));
    }
    IEnumerator StartMoving(int _canvas)
    {
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        parent.Hide();
        canvas.Canvases[_canvas].Show();
        FadeManager.Fade.FadeOut();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
    }
    IEnumerator UpdateScene(int _scene)
    {
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        SceneManager.LoadScene(_scene);
    }
}
