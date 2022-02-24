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
    public Vector2 GetPlayerMovement()
    {
        return playerInputActions.Player.Move.ReadValue<Vector2>();
    }
    public Vector2 MouseDelta()
    {
        return playerInputActions.Player.Look.ReadValue<Vector2>();
    }
}
