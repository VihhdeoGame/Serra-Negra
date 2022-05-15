using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent : MonoBehaviour
{
    ChangeScene changeScene;
    InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.PlayerInput;
        changeScene = GetComponent<ChangeScene>();
    }
    private void Update()
    {
        if(inputManager.StartButton())
        {
            changeScene.UpdateScene(1);
        }
        
    }

}
