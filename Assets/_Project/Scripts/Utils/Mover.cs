using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0.2f;

    private float _speed;
    private Rigidbody _rb;

    private PlayerController _pc;

    private Vector3 currentDirection;

    private void Awake()
    {
        if (_rb == null) _rb = GetComponentInParent<Rigidbody>();
        if (_pc == null) _pc = GetComponentInParent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (!_pc.isAlive) return;

        if (currentDirection.magnitude > 0.01f)
        {
            Vector3 velocity = currentDirection * _speed;
            _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);

            //Quaternion targetRotation = Quaternion.LookRotation(currentDirection);
            //Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            //_rb.MoveRotation(rotation);

        }
        else
        {
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f); // azzero per non avere l'inerzia nel movimento finale dopo aver smesso di premere i tasti di movimento cosi si ferma subito
        }
    }

    public void SetInput(Vector3 input)
    {
        currentDirection = input;
    }

    public void SetAndNormalizeInput(Vector3 input)
    {
        input.y = 0f;
        if (input.sqrMagnitude > 1f) input.Normalize();
        SetInput(input);
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
