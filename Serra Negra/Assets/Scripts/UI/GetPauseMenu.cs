using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPauseMenu : MonoBehaviour
{
    PauseMenu pause;
    private void OnEnable()
    {
        pause = FindObjectOfType<PauseMenu>();
    }
    public void Unpause()
    {
        pause.Unpause();
    }
}
