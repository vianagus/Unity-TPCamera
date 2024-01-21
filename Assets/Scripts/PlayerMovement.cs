using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 7.5f;
    private float _smoothFacing = 0.75f;
    private float _gravity = -9.8f;
    private Vector3 _movement;

    private CharacterController _characterController;
    private Transform _cameraTransform;

    private float _xInput;
    private float _yInput;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // handle input
        HandleInput();

        // gravity
        _movement.y = _gravity / 3f;

        // movement
        _movement.x = RelativeDirection().x;
        _movement.z = RelativeDirection().z;

        // facing rotation
        if(RelativeDirection().magnitude > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.LookRotation(RelativeDirection()), _smoothFacing * 10f * Time.deltaTime);

        // movement
        _characterController.Move(_movement * _moveSpeed * Time.deltaTime);
    }

    private void HandleInput()
    {
        // WASD
        _xInput = Input.GetAxisRaw("Vertical");
        _yInput = Input.GetAxisRaw("Horizontal");
    }

    private Vector3 RelativeDirection()
    {
        Vector3 zDir = _cameraTransform.forward;
        Vector3 xDir = _cameraTransform.right;
        zDir.y = 0;
        xDir.y = 0;

        return (zDir * _xInput + xDir * _yInput).normalized;
    }
}
