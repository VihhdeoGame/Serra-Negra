using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    AudioSource sfxPlayer;
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
    Vector2 cameraMove;
    Vector2 mouseMove;
    Vector2 offCenterPosition;
    [SerializeField]
    Transform povCam;
    DialogCanvas dialogCanvas;
    CursorController cursorController;
    public AudioSource SfxPlayer{get{return sfxPlayer;}}
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
        cursorController = FindObjectOfType<CursorController>();
        dialogCanvas = FindObjectOfType<DialogCanvas>(true);
        playerInput = InputManager.PlayerInput;
        targetGridPos = transform.position;
        prevTargetGridPos = targetGridPos;
        RecenterCamera();
    }

    void Update()
    {
        if(!dialogCanvas.Canvas.activeSelf && !cursorController.is2D)
        {
            cameraMove = playerInput.MouseDelta();
            if(playerInput.GetPlayerUp()){MoveFoward();}
            if(playerInput.GetPlayerDown()){MoveBackward();}
            if(playerInput.GetPlayerRight()){MoveRight();}
            if(playerInput.GetPlayerLeft()){MoveLeft();}
            if(playerInput.GetPlayerRotateRight()){RotateRight();}
            if(playerInput.GetPlayerRotateLeft()){RotateLeft();}
            if(Mathf.Abs(cameraMove.x)>0.1 || Mathf.Abs(cameraMove.y)>0.1){RotateCamera();}

            if(playerInput.GetInteraction())
            {
                RaycastHit hit;
                if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, gridSize) && !cursorController.is2D)
                {
                    Trigger3DDialog dialogCheck = hit.collider.gameObject.GetComponent<Trigger3DDialog>(); 
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
    private void FixedUpdate()
    {
        if(!AtRest) MovePlayer();
        if(AtRest && !dialogCanvas.Canvas.activeSelf) UpdateCamera();
    }

    void MovePlayer()
    {
        RaycastHit hit;
        if(Physics.Linecast (prevTargetGridPos, targetGridPos,out hit) && hit.transform.tag == "Wall")
        {            
            targetGridPos = prevTargetGridPos;
        }
        else
        {   
            prevTargetGridPos = targetGridPos;
            Vector3 TargetPosition = targetGridPos;
            
            if(targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
            if(targetRotation.y < 0f) targetRotation.y = 270f;

            if(!smoothTransition)
            {
                povCam.rotation = Quaternion.Euler(0,0,0);
                yaw = pitch = 0f;
                transform.position = TargetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
            else
            {
                povCam.localRotation = Quaternion.Slerp(povCam.localRotation, Quaternion.Euler(0,0,0), Time.fixedDeltaTime * mouseSpeed);
                yaw = pitch = 0f;
                transform.position = Vector3.MoveTowards(transform.position,targetGridPos, Time.fixedDeltaTime * transitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(targetRotation), Time.fixedDeltaTime * transitionRotationSpeed); 
            }
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
            yaw = Mathf.Clamp(yaw,-270,270);
            pitch -= cameraMove.y;
            pitch = Mathf.Clamp(pitch,-270,270); 
        }
    }
    void UpdateCamera()
    {
        povCam.localRotation = Quaternion.Euler(pitch* Time.fixedDeltaTime * mouseSpeed,yaw * Time.fixedDeltaTime * mouseSpeed,0);
        if(yaw != 0 || pitch != 0)
        {
            if(offCenterPosition.y == yaw && offCenterPosition.x == pitch)
            {
                offcenterTimer += Time.deltaTime;
                if(offcenterTimer > 1.5)
                    RecenterCamera();
                 
            }
            else
            {
                offcenterTimer = 0;
                offCenterPosition = new Vector2(pitch,yaw); 
            }
        }

    }
    void RecenterCamera()
    {
        Vector2 recenterPosition = Vector2.Lerp(offCenterPosition, Vector2.zero, Time.fixedDeltaTime * mouseSpeed);
        RecenterCursor(recenterPosition);
    }
    void RecenterCursor(Vector2 _recenterPosition)
    {
        yaw = _recenterPosition.y;
        pitch = _recenterPosition.x;
        offCenterPosition = new Vector2(pitch,yaw);
    }
}