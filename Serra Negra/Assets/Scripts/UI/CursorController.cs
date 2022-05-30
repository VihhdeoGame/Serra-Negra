using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public bool is2D;
    [SerializeField]
    Texture2D cursor;
    [SerializeField]
    Texture2D cursorClicked;
    InputManager playerInput;
    GameObject crosshair;
    bool click;
    private void Start()
    {   
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        playerInput = InputManager.PlayerInput;
        if(is2D)
        {
            EnableCursor();
        }
        else
        {
           DisableCursor();
        }
    }
    private void Update() 
    {
        if(click && !playerInput.Clicked())
        {
            click = false;
            EndClick();
        }
        if(!click && playerInput.Clicked())
        {
            click = true;
            StartedClick();
        }   
    }
    public void ChangeCursor(Texture2D _cursorType)
    {
        Vector2 hotspot = new Vector2(0, _cursorType.height);
        Cursor.SetCursor(_cursorType, hotspot, CursorMode.Auto);
    }
    void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }
    void EndClick()
    {
        ChangeCursor(cursor);
    }
    public void DisableCursor()
    {
        crosshair.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void EnableCursor()
    {
        ChangeCursor(cursor);
        crosshair.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
