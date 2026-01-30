using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _currenthp;
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private bool _fullHPOnStart = true;

    [SerializeField] private UnityEvent<int, int> _onHPChanged;
    [SerializeField] private UnityEvent _onDefeated;

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
                Defeated();
                _onDefeated.Invoke();
            }
        }
    }

    public void AddHp(int amount) => SetHp(_currenthp + amount);

    public void TakeDamage(int damage)
    {
        Debug.Log($"Life Controller takedamage con damage ={damage}");
        AddHp(-damage);
    }

    public void Defeated()
    {
        Destroy(gameObject);
    }
}
