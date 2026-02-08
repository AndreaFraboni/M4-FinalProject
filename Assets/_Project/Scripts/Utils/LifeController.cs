using UnityEngine;
using UnityEngine.Events;
public class LifeController : MonoBehaviour
{
    [Header("Health Referements")]
    [SerializeField] private int _currenthp;
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private bool _fullHPOnStart = true;
    [Header("Unity Event on Health Event")]
    [SerializeField] private UnityEvent<int, int> _onHPChanged;
    [SerializeField] private UnityEvent _onDefeated;
    [Header("Player Referements")]
    [SerializeField] private PlayerController _pc;

    private void Awake()
    {
        if (_pc == null) _pc = GetComponent<PlayerController>();
    }

    // Getter
    public int GetHp() => _currenthp;
    public int GetMaxHp() => _maxHP;

    private void Start()
    {
        if (_fullHPOnStart) SetHp(_maxHP);
    }

    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHP);

        if (hp != _currenthp)
        {
            _currenthp = hp;

            _onHPChanged.Invoke(_currenthp, _maxHP);

            if (_currenthp <= 0)
            {
                _onDefeated.Invoke();
            }
        }
    }

    public void AddHp(int amount)
    {
        if (amount < 0)
        {
            _pc.GetDamageSfx();
        }
        else
        {
            _pc.GetHeartSfx();
        }

        SetHp(_currenthp + amount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }
}
