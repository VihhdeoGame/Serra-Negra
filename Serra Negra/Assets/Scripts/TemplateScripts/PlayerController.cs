using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool smoothTransition = false;
    [SerializeField]
    float transitionSpeed = 10f;
    float transitionRotationSpeed = 500f;
    float gridSize = 3f;

    InputManager playerInput;
    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;
    Vector2 playerMove;
    bool AtRest
    {
        get
        {
            if((Vector3.Distance(transform.position, targetGridPos) < 0.05f) &&
               (Vector3.Distance(transform.eulerAngles,targetRotation) < 0.05f))
                
                return true;
            else

                return false;
        }
    }
        private void Start()
    {
        playerInput = InputManager.PlayerInput;
        targetGridPos = transform.position;
        prevTargetGridPos = targetGridPos;
    }

    void Update()
    {
        playerMove = playerInput.GetPlayerMovement();
        if(playerMove.y > 0.1f){MoveFoward();}
        if(playerMove.y < -0.1f){MoveBackward();}
        if(playerMove.x > 0.1f){RotateRight();}
        if(playerMove.x < -0.1f){RotateLeft();}
        if(playerInput.GetPlayerRight()){MoveRight();}
        if(playerInput.GetPlayerLeft()){MoveLeft();}
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if(!Physics.Linecast (prevTargetGridPos, targetGridPos))
        {
            prevTargetGridPos = targetGridPos;
            Vector3 TargetPosition = targetGridPos;
            
            if(targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
            if(targetRotation.y < 0f) targetRotation.y = 270f;

            if(!smoothTransition)
            {
                transform.position = TargetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,targetGridPos, Time.fixedDeltaTime * transitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(targetRotation), Time.fixedDeltaTime * transitionRotationSpeed); 
            }

        }
        else
        {
            targetGridPos = prevTargetGridPos;
        }

    }

    void RotateLeft() {if (AtRest) targetRotation -= Vector3.up * 90f;}
    void RotateRight() {if (AtRest) targetRotation += Vector3.up * 90f;}
    void MoveFoward() {if (AtRest) targetGridPos += transform.forward * gridSize;}
    void MoveBackward() {if (AtRest) targetGridPos -= transform.forward * gridSize;}
    void MoveLeft() {if (AtRest) targetGridPos -= transform.right * gridSize;}
    void MoveRight() {if (AtRest) targetGridPos += transform.right * gridSize;}

}