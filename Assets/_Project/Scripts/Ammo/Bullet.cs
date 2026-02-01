using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeSpan = 5f;

    public float _speed = 10f;

    private Mover _mover;

    private void Awake()
    {
        if (_mover == null) _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        Destroy(gameObject, _lifeSpan);
    }

    public void Shoot(Vector3 dir)
    {
        _mover.SetSpeed(_speed);
        _mover.SetAndNormalizeInput(dir);
    }

    private void OnTriggerEnter(Collider other)
    {



    }

}
