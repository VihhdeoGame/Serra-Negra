using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartCutscene : MonoBehaviour
{
    float waitTime;
    [SerializeField]
    MainGameCanvas canvas;
    private void Start()
    {
        PlayCutscene();
    }

    void PlayCutscene()
    {
        canvas.Canvases[0].Show();
    }


}
