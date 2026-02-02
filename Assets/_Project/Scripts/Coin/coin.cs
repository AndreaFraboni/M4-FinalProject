using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private float coinSpeed = 100f;
    [SerializeField] private int coinValue = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(coinSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            Debug.Log("TRIGGER WITH PLAYER");
            other.gameObject.GetComponent<PlayerController>().GetCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
