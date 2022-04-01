using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    InputManager playerInput;
    private void Start() 
    {
        playerInput = InputManager.PlayerInput;        
    }
    private void Update() 
    {
        if(playerInput.GetInteraction())
        {
            Ray ray = Camera.main.ScreenPointToRay(playerInput.GetMousePosition());
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if(hit.collider != null)
            {
                Trigger2DDialog dialogCheck = hit.collider.gameObject.GetComponent<Trigger2DDialog>();
                if(dialogCheck != null)
                {
                    if(dialogCheck.requiredCheck)
                    {
                        if(dialogCheck.CheckFlag())
                        {
                            dialogCheck.CheckDialog(1);
                        }
                        else
                        {
                            dialogCheck.CheckDialog(0);
                        }
                    }
                    else
                    {
                        dialogCheck.CheckDialog(0);                            
                    }
                }
            }   
        } 
    } 
}
