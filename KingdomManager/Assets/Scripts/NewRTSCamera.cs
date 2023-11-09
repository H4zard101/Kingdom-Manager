using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRTSCamera : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _smoothing = 5f;

    [SerializeField] private Vector2 _cameraRange = new(100, 100);

    private Vector3 _targetPosition;
    private Vector3 _input;

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void HandleInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 right = transform.right * x;
        Vector3 forward = transform.forward * z;

        _input = (forward + right).normalized;
    }

    private void Move()
    {
        Vector3 nextTargetPosition = _targetPosition + _input * _speed;
        if(IsInBounds(nextTargetPosition)) _targetPosition = nextTargetPosition;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _smoothing);
    }

    private bool IsInBounds(Vector3 position)
    {
        return position.x > -_cameraRange.x &&
               position.x < _cameraRange.x &&
               position.z > -_cameraRange.y &&
               position.z < _cameraRange.y;
    }
    private void Update()
    {
        HandleInput();
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1f);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(_cameraRange.x * 2f, 5f, _cameraRange.y * 2f));
    }
}
