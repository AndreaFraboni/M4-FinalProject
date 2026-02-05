using UnityEngine;

public class MagicSphere : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int _damage = 10;

    [Header("Lifetime")]
    [SerializeField] private float _lifeSpan = 5f;

    [Header("Movement")]
    [SerializeField] private float _speed = 10f;

    private Rigidbody _rb;

    private Vector3 _movedir;

    private void Awake()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Destroy(gameObject, _lifeSpan);
    }

    //private void FixedUpdate()
    //{
    //    if (_movedir != Vector3.zero)
    //    {
    //        //_rb.MovePosition(transform.position + _movedir * (_speed * Time.fixedDeltaTime));           
    //    }
    //}

    public void Shoot(Vector3 dir)
    {
        if (dir.sqrMagnitude < 0.0001f) return;
        if (dir.sqrMagnitude > 1f) dir.Normalize();
        _movedir = dir;

        _rb.velocity = _movedir * _speed;

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other != null)
        //{
        //    if (other.gameObject.TryGetComponent<LifeController>(out LifeController _lifeController))
        //    {
        //        _lifeController.TakeDamage(_damage);
        //        Destroy(gameObject);
        //    }
        //}
    }
}
