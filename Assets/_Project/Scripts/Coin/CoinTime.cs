using UnityEngine;

public class CoinTime : MonoBehaviour
{

    [SerializeField] private float coinSpeed = 100f;
    [SerializeField] private int coinValue = 20;

    [SerializeField] private Timer _timer;
    [SerializeField] private float addtime = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(coinSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            _timer.AddTime(addtime);
            Debug.Log("TRIGGER WITH PLAYER");
            other.gameObject.GetComponent<PlayerController>().GetCoins(coinValue);
            Destroy(gameObject);
        }
    }

}
