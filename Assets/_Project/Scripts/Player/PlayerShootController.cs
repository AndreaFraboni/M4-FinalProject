using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private float _fireInterval = 0.5f;
    [SerializeField] private float _maxDistance = 100f;

    [SerializeField] private GameObject _firePoint;

    private float _lastShootTime;

    private Camera _cam;
    private Ray _ray;
    private float _hitPointRadius = 0.15f;

    private Vector3 _direction;

    private void Awake()
    {
        _cam = Camera.main;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_ray.origin, _ray.direction * _maxDistance);

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxDistance))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hit.point, _hitPointRadius);
        }
    }

    public void ShootRay(Ray ray)
    {
        _lastShootTime = Time.time;

        _ray = ray;

        Vector3 start = _ray.origin;
        Vector3 direction = _ray.direction;

        if (Physics.Raycast(start, direction, out RaycastHit hit, _maxDistance))
        {
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<IHitable>(out IHitable hitableobj))
                {
                    hitableobj.GetHit();
                }
            }
        }
    }
    public void ShootBullet(Vector3 direction)
    {
        _lastShootTime = Time.time;

        //Bullet clonedBullet = Instantiate(_bulletPrefab);
        //clonedBullet.transform.position = _firePoint.transform.position;
        //clonedBullet.Shoot(direction);
    }
    public void TryToShoot(Vector3 direction)
    {
        if (CanShootNow())
        {
            ShootBullet(direction);
        }
    }

    public bool CanShootNow()
    {
        return Time.time - _lastShootTime > _fireInterval;
    }

    public void TryToShootRay(Ray ray)
    {
        if (CanShootNow())
        {
            ShootRay(ray);
        }
    }


}

