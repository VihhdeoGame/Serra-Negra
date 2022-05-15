using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    Texture2D cursor;
    [SerializeField]
    Texture2D cursorClicked;
    InputManager playerInput;
    bool click;
    private void Awake() 
    {
        ChangeCursor(cursor);
    }
    private void Start()
    {
        playerInput = InputManager.PlayerInput;
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
    private void ChangeCursor(Texture2D _cursorType)
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
   
}
