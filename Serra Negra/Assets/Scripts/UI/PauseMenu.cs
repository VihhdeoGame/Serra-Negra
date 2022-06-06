using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    InputManager playerInput;
    bool paused = false;
    GameObject crosshair;
    [SerializeField]
    GameObject pauseCanvas;
    CursorController cursorController;
    private void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        cursorController = FindObjectOfType<CursorController>();
        playerInput = InputManager.PlayerInput;
    }
    private void Update()
    {
        if(!paused && playerInput.Pause())
        {
            Pause();
        }
        else if(paused && playerInput.Pause())
        {
            Unpause();
        }
                
    }
    public void Pause()
    {
        paused = true;
        playerInput.DisablePlayerInput();
        if(!cursorController.is2D)
            cursorController.EnableCursor();
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        paused = false;
        playerInput.EnablePlayerInput();
        if(!cursorController.is2D)
            cursorController.DisableCursor();
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
