﻿using UnityEngine;

public class TPCamera : MonoBehaviour
{
    #region Variable

    // inspector target
    [Header("Target")]
    [SerializeField] Transform _follow;
    [SerializeField] Transform _lookAt;

    // inspector look at
    [Header("Look At")]
    [SerializeField] Vector3 _lookAtOffset = new Vector3(0f, 2f, 0f);

    // inspector position
    [Header("Position")]
    [SerializeField] float _maxDistance = 10f;
    [Range(0f, 1f)] [SerializeField] float _smoothDamp = 0.1f;

    // inspector rotation
    [Header("Rotation")]
    [SerializeField] float _yawSensitivity = 1f;
    [SerializeField] float _pitchSensitivity = 1f;
    [SerializeField] float _minPitch = -10f;
    [SerializeField] float _maxPitch = 60f;

    // inspector obstacle detection
    [Header("Obstacle Detection")]
    [SerializeField] bool _avoidObstacle = true;
    [SerializeField] LayerMask _obstacleLayer;
    [SerializeField] float _distanceToObstacle = 0.5f;
    [SerializeField] float _heightToObstacle = 0.5f;

    // private look at position
    private Vector3 _lookAtPosition;

    // private position
    private float _distance;
    private Vector3 _position;
    private Vector3 _refCurrentDampVelocity;

    // private rotation
    private float _yaw;
    private float _pitch;
    private Quaternion _rotation;

    // private raycasting (for obstacle detection)
    private Ray _ray;
    private RaycastHit _raycastHit;

    #endregion

    #region Unity

    private void Start()
    {
        _yaw = 0f;                      // set default yaw
        _pitch = 30f;                   // set default pitch
        _distance = _maxDistance;       // set default distance
    }

    private void LateUpdate()
    {
        // handle input
        HandleInput();

        // set final LookAt position
        _lookAtPosition = _lookAt.position + _lookAtOffset;

        // handle clipping
        HandleObstacle(_maxDistance);

        // handle position
        HandlePosition();

        // apply LookAt position
        transform.LookAt(_lookAtPosition);
    }

    #endregion

    #region Handler

    private void HandleInput()
    {
        _yaw += Input.GetAxis("Mouse X") * _yawSensitivity;
        _pitch -= Input.GetAxis("Mouse Y") * _pitchSensitivity;
    }

    private void HandleObstacle(float rayDistance)
    {
        if(_avoidObstacle)
        {
            // set ray
            _ray = new Ray(_lookAtPosition, (transform.position - _lookAtPosition).normalized);
            
            // detect collision and set camera distance
            if(Physics.Raycast(_ray, out _raycastHit, rayDistance, _obstacleLayer))
                _distance = _raycastHit.distance - _distanceToObstacle;
            else
                _distance = _maxDistance;
        }
    }

    private void HandlePosition()
    {
        // limit pitch
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        // set target rotation and position
        _rotation = Quaternion.Euler(_pitch, _yaw, 0f);        
        _position = _follow.position + Vector3.up * (_lookAtOffset.y + _heightToObstacle) + _rotation * (Vector3.forward * -_distance);

        // set rotation and position
        transform.rotation = _rotation;
        transform.position = Vector3.SmoothDamp( transform.position, _position, ref _refCurrentDampVelocity, _smoothDamp);
    }

    #endregion
}
