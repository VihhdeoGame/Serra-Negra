using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void UpdateScene(int _scene)
    {
        StopAllCoroutines();
        StartCoroutine(UpdateS(_scene));
    }
    IEnumerator UpdateS(int _scene)
    {
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        SceneManager.LoadScene(_scene);
    }
    public void QuitGame()
    {
        StopAllCoroutines();
        StartCoroutine(Quit());
    }
    IEnumerator Quit()
    {
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        Application.Quit();
    }
}
