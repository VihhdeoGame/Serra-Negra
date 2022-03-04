using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool smoothTransition = false;
    [SerializeField]
    float transitionSpeed = 10f;
    float transitionRotationSpeed = 500f;
    float mouseSpeed = 10f;
    float gridSize = 3f;
    float yaw = 0f;
    float pitch = 0f;
    float offcenterTimer = 0f;

    InputManager playerInput;
    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;
    Vector2 playerMove;
    Vector2 cameraMove;
    Vector2 mouseMove;
    Vector2 offCenterPosition;
    [SerializeField]
    Transform povCam;

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
        RecenterCamera();
    }

    void Update()
    {
        playerMove = playerInput.GetPlayerMovement();
        cameraMove = playerInput.MouseDelta();
        if(playerMove.y > 0.1f){MoveFoward();}
        if(playerMove.y < -0.1f){MoveBackward();}
        if(playerMove.x > 0.1f){RotateRight();}
        if(playerMove.x < -0.1f){RotateLeft();}
        if(playerInput.GetPlayerRight()){MoveRight();}
        if(playerInput.GetPlayerLeft()){MoveLeft();}
        if(Mathf.Abs(cameraMove.x)>0.1 || Mathf.Abs(cameraMove.y)>0.1){RotateCamera();}
    }
    private void FixedUpdate()
    {
        if(!AtRest) MovePlayer();
        if(AtRest) UpdateCamera();
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
                RecenterCamera();
                transform.position = TargetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
            else
            {
                RecenterCamera();
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
    void RotateCamera()
    {
        if (AtRest)
        {
            yaw += cameraMove.x;
            yaw = Mathf.Clamp(yaw,-75,75);
            pitch -= cameraMove.y;
            pitch = Mathf.Clamp(pitch,-75,75); 
        }
    }
    void UpdateCamera()
    {
        povCam.localRotation = Quaternion.Euler(pitch* Time.fixedDeltaTime * mouseSpeed,yaw * Time.fixedDeltaTime * mouseSpeed,0);
        if(yaw != 0 || pitch != 0)
        {
            if(offCenterPosition.x == yaw && offCenterPosition.y == pitch)
            {
                offcenterTimer += Time.deltaTime;
                if(offcenterTimer > 1.5) RecenterCamera();
            }
            else
            {
                offcenterTimer = 0;
                offCenterPosition = new Vector2(yaw,pitch); 
            }
        }

    }
    void RecenterCamera()
    {
        povCam.localRotation = Quaternion.Lerp(povCam.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime * mouseSpeed);
        yaw = 0;
        pitch = 0;
    }
}