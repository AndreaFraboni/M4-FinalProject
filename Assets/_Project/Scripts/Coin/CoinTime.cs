using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CoinTime : MonoBehaviour
{
    [Header("COIN time parameters")]
    [SerializeField] private float _coinRotSpeed = 100f;
    [SerializeField] private int _coinValue = 20;
    [SerializeField] private Timer _timer;
    [SerializeField] private float addtime = 10;

    private void Awake()
    {
        if (_timer == null)
        {
            _timer = FindAnyObjectByType<Timer>();
        }
    }

    void Update()
    {
        transform.Rotate(_coinRotSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            _timer.AddTime(addtime);
            Debug.Log("TRIGGER WITH PLAYER");
            other.gameObject.GetComponent<PlayerController>().GetCoins(_coinValue);
            Destroy(gameObject);
        }
    }

}
