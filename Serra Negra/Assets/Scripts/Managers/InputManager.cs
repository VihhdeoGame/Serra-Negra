using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    private static InputManager playerInput;
    public static InputManager PlayerInput{ get{ return playerInput; } }
    private PlayerInputActions playerInputActions;

    private void Awake() 
    {
        if(playerInput != null && playerInput != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerInput = this;
        }
        playerInputActions = new PlayerInputActions();        
    }
    private void OnEnable()
    {
        playerInputActions.Enable();        
    }
    private void OnDisable()
    {
        playerInputActions.Disable();        
    }
    public bool GetPlayerUp()
    {
        return playerInputActions.Player.MoveUp.triggered;
    }
    public bool GetPlayerDown()
    {
        return playerInputActions.Player.MoveDown.triggered;
    }
    
    public bool GetPlayerLeft()
    {
        return playerInputActions.Player.MoveLeft.triggered;
    }
    
    public bool GetPlayerRight()
    {
        return playerInputActions.Player.MoveRight.triggered;
    }
    public Vector2 MouseDelta()
    {
        return playerInputActions.Player.Look.ReadValue<Vector2>();
    }
    public bool GetPlayerRotateRight()
    {
        return playerInputActions.Player.RotateRight.triggered;
    }
    public bool GetPlayerRotateLeft()
    {
        return playerInputActions.Player.RotateLeft.triggered;
    }
    public bool GetInteraction()
    {
        return playerInputActions.Player.Interact.triggered;
    }
    public Vector2 GetMousePosition()
    {
        return playerInputActions.Player.MousePosition.ReadValue<Vector2>();
    }
    public bool Clicked()
    {
        return playerInputActions.UI.Click.IsPressed();
    }
    public bool StartButton()
    {
        return playerInputActions.UI.StartButton.triggered;
    }
    public bool Pause()
    {
        return playerInputActions.UI.Pause.triggered;
    }
    public void DisablePlayerInput()
    {
        playerInputActions.Player.Disable();
    }
    
    public void EnablePlayerInput()
    {
        playerInputActions.Player.Enable();
    }
}
