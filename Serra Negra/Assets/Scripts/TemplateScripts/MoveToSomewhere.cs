using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToSomewhere : MonoBehaviour
{
    [SerializeField]
    bool check;
    bool moving = false;
    [SerializeField]
    MainGameCanvas canvas;
    GenericCanvas parent;
    Trigger2DDialog dialog;
    AudioSource sfxPlayer;
    [SerializeField]
    AudioClip transitionAudio;
    private void OnEnable()
    {
        sfxPlayer = GameObject.FindGameObjectWithTag("SFXPlayer").GetComponent<AudioSource>();
        parent = gameObject.GetComponentInParent<GenericCanvas>();
    }
    private void OnDisable()
    {
        moving = false;
    }
    public void Move(int _canvas)
    {
        if(!check && !moving)
        {
            StopAllCoroutines();
            StartCoroutine(StartMoving(_canvas));
        }
        else if(check && !moving)
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
        if(transitionAudio != null)sfxPlayer.PlayOneShot(transitionAudio);
        moving = true;
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        parent.Hide();
        canvas.Canvases[_canvas].Show();
        FadeManager.Fade.FadeOut();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        moving = false;
    }
    IEnumerator UpdateScene(int _scene)
    {
        if(transitionAudio != null)sfxPlayer.PlayOneShot(transitionAudio);
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        SceneManager.LoadScene(_scene);
    }

    public void GameOver(int _scene)
    {
        StopAllCoroutines();
        StartCoroutine(Over());
        IEnumerator Over()
        {
            yield return new WaitForSeconds(5);
            StartCoroutine(UpdateScene(_scene));
        }
    }
}
