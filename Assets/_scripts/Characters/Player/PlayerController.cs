using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float verticalRotationLimit = 80f;

    private CharacterController characterController;
    private Transform cameraTransform;
    private float verticalSpeed = 0f;
    private const float gravity = -9.81f;
    private float verticalRotation = 0f;
    private bool IsQuestMode;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (IsQuestMode == false)
        {
            MovePlayer();
            RotatePlayer();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("1");
        }
    }

    private void MovePlayer()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        float moveDirectionX = Input.GetAxis("Horizontal") * speed;
        float moveDirectionZ = Input.GetAxis("Vertical") * speed;
     
        if (characterController.isGrounded)    
            verticalSpeed = 0f;       
        else        
            verticalSpeed += gravity * Time.deltaTime; 
       
        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;
        move.y = verticalSpeed;

        characterController.Move(move * Time.deltaTime);     
    }
    private void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
