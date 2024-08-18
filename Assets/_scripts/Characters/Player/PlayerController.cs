using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private float _verticalRotationLimit = 80f;

    [Space]
    [SerializeField] private Transform _flashlight;
   //[SerializeField] private Vector3 _flashlightOffset;

    private CharacterController _characterController;
    private PlayerInteraction _playerInteraction;
    private Transform _cameraTransform;
    private float _verticalSpeed = 0f;
    private const float _gravity = -9.81f;
    private float _verticalRotation = 0f;
    private bool IsQuestMode = false;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
        _playerInteraction = GetComponent<PlayerInteraction>();
    }

    private void Update()
    {
        if (IsQuestMode == false)
        {
            MovePlayer();
            RotatePlayer();
            RotateFlashlight();
        }
        else
        {
            ApplyGravity();
        }
    }

    public void SwitchQuestMode()
    {
        IsQuestMode = !IsQuestMode;         
    }
    public void OffQuestMode()
    {
        IsQuestMode = false;
    }

    private void MovePlayer()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;

        float moveDirectionX = Input.GetAxis("Horizontal") * speed;
        float moveDirectionZ = Input.GetAxis("Vertical") * speed;

        ApplyGravity();

        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;
        move.y = _verticalSpeed;

        _characterController.Move(move * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded)
            _verticalSpeed = 0f;
        else
            _verticalSpeed += _gravity * Time.deltaTime;

        _characterController.Move(new Vector3(0, _verticalSpeed, 0) * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _verticalRotation -= mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -_verticalRotationLimit, _verticalRotationLimit);

        _cameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    private void RotateFlashlight()
    {
        if (_flashlight != null)
        {
            _flashlight.position = _cameraTransform.position;// + _flashlightOffset;  // Ensure the flashlight follows the camera's position
            _flashlight.rotation = _cameraTransform.rotation;  // Ensure the flashlight follows the camera's rotation
        }
    }
}
