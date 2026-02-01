using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _target;

    [SerializeField] float _mouseSensitivity = 5f;

    [SerializeField] float bottomClamp = -20f;
    [SerializeField] float topClamp = 60f;

    [SerializeField] float _maxZoomDistance = 10f;
    [SerializeField] float _minZoomDistance = 2f;
    private float orbitRadius = 5f;

    [SerializeField] Vector3 offset = new Vector3(0, 2, -5);

    [SerializeField] private float _startYaw = 0f;
    [SerializeField] private float _startPitch = 0f;

    private float _yaw = 0f;
    private float _pitch = 0f;

    private void Start()
    {
        _yaw = _startYaw;
        _pitch = _startPitch;
        _pitch = Mathf.Clamp(_pitch, bottomClamp, topClamp);
    }

    private void LateUpdate()
    {
        if (_target == null) return;

        if (Input.GetMouseButton(1))
        {
            //transform.LookAt(_target);
            //_yaw = Input.GetAxis("Mouse X") * _mouseSensitivity;
            //_pitch = Input.GetAxis("Mouse Y") * _mouseSensitivity;
            //_pitch = Mathf.Clamp(_pitch, bottomClamp, topClamp);
            //transform.eulerAngles += new Vector3(-_pitch, _yaw, 0);

            _yaw += Input.GetAxis("Mouse X") * _mouseSensitivity;
            _pitch -= Input.GetAxis("Mouse Y") * _mouseSensitivity;
            _pitch = Mathf.Clamp(_pitch, bottomClamp, topClamp);

            Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
            Vector3 desiredPosition = _target.position + rotation * offset;

            Vector3 lookAt = _target.position + Vector3.up * 2;
            Quaternion lookRotation = Quaternion.LookRotation(lookAt - desiredPosition);
            transform.SetPositionAndRotation(desiredPosition, lookRotation);
        }

        orbitRadius -= Input.mouseScrollDelta.y / _mouseSensitivity;
        orbitRadius = Mathf.Clamp(orbitRadius, _minZoomDistance, _maxZoomDistance);
        transform.position = _target.position - transform.forward * orbitRadius;

    }
}
