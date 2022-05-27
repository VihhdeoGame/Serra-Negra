using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitToMainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject warningPanel;
    PauseMenu pauseMenu;
    private void OnEnable()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();        
    }
    public void DisplayWarning()
    {
        warningPanel.SetActive(true);
    }
    public void HideWarning()
    {
        warningPanel.SetActive(false);
    }
    public void ExitToMenu()
    {
        StopAllCoroutines();
        StartCoroutine(Exit());
    }
    IEnumerator Exit()
    {
        HideWarning();
        Time.timeScale = 1;
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        SceneManager.LoadScene(0);
    }
}
