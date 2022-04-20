using System.Collections;
using UnityEngine;
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
    IEnumerator UpdateScene(int _scene)
    {
        Debug.Log("mova caralho");
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        //Insira aqui o metodo para atualizar a cena, weeee.
    }
}
