using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, IHitable
{
    [Header("Life Bar UI")]
    [SerializeField] private Image _bar_lifeBarFillable;

    [Header("Audio Manager")]
    [SerializeField] private AudioManager _audioManager;

    private LifeController _lifeController;

    private void Awake()
    {
        if (_lifeController == null) _lifeController = GetComponentInParent<LifeController>();
        if (_audioManager == null) _audioManager = FindAnyObjectByType<AudioManager>();

    }







    public void GetHit()
    {
        _lifeController.TakeDamage(10);
    }

    public void OnChangeLife(int hp, int maxhp)
    {
        _audioManager.PlaySFX("GetDamage");

        _bar_lifeBarFillable.fillAmount = (float)hp / maxhp;
    }

    public void OnDefeated()
    {
        _audioManager.PlaySFX("DeathSound");
        Destroy(gameObject);
    }

}
