using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("COIN parameters")]
    [SerializeField] private float _coinRotSpeed = 100f;
    [SerializeField] private int _coinValue = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_coinRotSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            //Debug.Log("TRIGGER WITH PLAYER");
            other.gameObject.GetComponent<PlayerController>().GetCoins(_coinValue);
            Destroy(gameObject);
        }
    }
}
