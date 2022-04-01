using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    public bool is2D;
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
        if(!is2D)
        {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
    public Vector2 GetPlayerMovement()
    {
        return playerInputActions.Player.Move.ReadValue<Vector2>();
    }
    public Vector2 MouseDelta()
    {
        return playerInputActions.Player.Look.ReadValue<Vector2>();
    }
    public bool GetPlayerRight()
    {
        return playerInputActions.Player.MoveRight.triggered;
    }
    public bool GetPlayerLeft()
    {
        return playerInputActions.Player.MoveLeft.triggered;
    }
    public bool GetInteraction()
    {
        return playerInputActions.Player.Interact.triggered;
    }

    public Vector2 GetMousePosition()
    {
        return playerInputActions.Player.MousePosition.ReadValue<Vector2>();
    }

}
