using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    [Header("HEART parameters")]
    [SerializeField] private float _rotSpeed = 100f;
    [SerializeField] private int _value = 10;

    [Header("Audio Manager")]
    [SerializeField] private AudioManager _audioManager;

    private void Awake()
    {
        if (_audioManager == null) _audioManager = FindAnyObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<LifeController>(out LifeController life)) return;
        life.AddHp(_value);
        Destroy(gameObject);
    }
}
