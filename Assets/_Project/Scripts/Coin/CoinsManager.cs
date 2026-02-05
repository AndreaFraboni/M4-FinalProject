using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentCoinstext;
    [SerializeField] private PlayerController _pc;

    public int _coinsToPickup = 100;
    public int _currentCoins = 0;

    private void Awake()
    {
        if (_pc == null) _pc = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        if (_pc != null)
        {
            _currentCoins = _pc._currentCoins;
            _currentCoinstext.text = $"{_currentCoins}/{_coinsToPickup}";
        }
    }

    private void Update()
    {
        if (_currentCoins >= _coinsToPickup)
        {
            /// TO DO ==>  YOU WIN !!!!!!!!!!!
            /// 
            // use unity event ....

        }
    }

    public void OnCoinPickup(int currentcoins)
    {
        _currentCoins = currentcoins;
        _currentCoinstext.text = $"{currentcoins}/{_coinsToPickup}";
    }
}
