using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, IHitable
{
    [SerializeField] private Image _bar_lifeBarFillable;

    private LifeController _lifeController;

    private void Awake()
    {
        if (_lifeController == null) _lifeController = GetComponentInParent<LifeController>();
    }







    public void GetHit()
    {
        _lifeController.TakeDamage(10);
    }

    public void OnChangeLife(int hp, int maxhp)
    {
        _bar_lifeBarFillable.fillAmount = (float)hp / maxhp;
    }

    public void OnDefeated()
    {
        Destroy(gameObject);
    }

}
