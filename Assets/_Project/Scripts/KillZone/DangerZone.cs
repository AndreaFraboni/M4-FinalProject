using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] int _damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<LifeController>(out LifeController _life))
        {
            _life.TakeDamage(_damage);
        }
    }

}
