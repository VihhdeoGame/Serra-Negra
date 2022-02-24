using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private InputManager playerInput;
    private CharacterController controller;
    public Transform movePoint;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float gridSize;
    [SerializeField]
    private CinemachineVirtualCamera vCam;

    private void Start()
    {
        movePoint.parent = null;
        controller = GetComponent<CharacterController>();
        playerInput = InputManager.PlayerInput;
    }

    void Update()
    {
        Move(playerInput.GetPlayerMovement());
    }

    public void RotateSelf(Vector2 _movement)
    {
        if(transform.rotation != movePoint.rotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, movePoint.rotation, Time.deltaTime * playerSpeed);
        }
        else
            if(Mathf.Abs(_movement.x)>0.1f)
            {
                movePoint.rotation = Quaternion.Euler(0,movePoint.rotation.y + (_movement.normalized.x*90),0);
            }
    }
    public void Move(Vector2 _movement)
    {
        Vector3 offset = movePoint.position - transform.position;
        if(offset.magnitude > .1f)
        {
            offset = offset.normalized * playerSpeed;
            controller.Move(offset * Time.deltaTime);
        }
        else 
            if(Mathf.Abs(_movement.y)>0.1f)
                movePoint.position += new Vector3(0,0,_movement.normalized.y*gridSize);
    }    
}