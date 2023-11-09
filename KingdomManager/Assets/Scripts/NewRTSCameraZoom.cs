using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRTSCameraZoom : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    [SerializeField] private float _smoothing = 5f;

    [SerializeField] private Vector2 _cameraRange = new(10, 70);
    [SerializeField] private Transform _cameraHolder;

    private Vector3 _cameraDirection => transform.InverseTransformDirection(_cameraHolder.forward);

    private Vector3 _targetPosition;
    private float _input;

    private void Awake()
    {
        _targetPosition = _cameraHolder.localPosition;
    }

    private void HandleInput()
    {
        _input = Input.GetAxisRaw("Mouse ScrollWheel");
    }

    private void Zoom()
    {
        Vector3 nextTargetPosition = _targetPosition + _cameraDirection * (_input * _speed);
        if(IsInBounds(nextTargetPosition)) _targetPosition = nextTargetPosition;
        _cameraHolder.localPosition = Vector3.Lerp(_cameraHolder.localPosition, _targetPosition, Time.deltaTime * _smoothing);
    }
    private bool IsInBounds(Vector3 position)
    {
        return position.magnitude > _cameraRange.x && position.magnitude < _cameraRange.y;
    }

    private void Update()
    {
        HandleInput();
        Zoom();
    }
}
