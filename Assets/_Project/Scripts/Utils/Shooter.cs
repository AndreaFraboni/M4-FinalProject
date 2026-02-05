using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private MagicSphere _MagicSpherePrefab;
    [SerializeField] private float _fireInterval = 0.5f;

    private float _lastShootTime;

    public void Shoot(Vector3 direction)
    {
        _lastShootTime = Time.time;

        //MagicSphere clonedBullet = Instantiate(_MagicSpherePrefab);
        //clonedBullet.transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * _offset;
        //clonedBullet.Shoot(direction);
    }

    public bool CanShootNow()
    {
        return Time.time - _lastShootTime > _fireInterval;
    }

    public void TryToShoot(Vector3 direction)
    {
        if (CanShootNow())
        {
            Shoot(direction);
        }
    }






}
