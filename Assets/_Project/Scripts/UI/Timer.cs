using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _countDown = 600f; // Durata del timer in secondi = 10 minuti
    [SerializeField] private float _currentTime;
    [SerializeField] private TextMeshProUGUI _currentTimetext;

    public GameObject gameOver;
    public GameObject menuGameOver;

    AudioManager _audioManager;

    private void Awake()
    {
        _currentTimetext.text = $"{(int)_currentTime} s";
        _currentTime = _countDown;
        if (_audioManager == null) _audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

        TimeManager();

        if (_currentTime <= 0)
        {
            _currentTime = 0;
            Invoke("GameOver", 0.5f);
        }
    }

    private void TimeManager()
    {
        int secondiTrascorsi = (int)_currentTime;
        _currentTimetext.text = $"{secondiTrascorsi} s";
    }

    public void AddTime(float value)
    {
        _audioManager.PlaySFX("PickupCoinTimer");
        _currentTime += value;
        if (_currentTime >= _countDown) _currentTime = _countDown;
    }

    public void GameOver()
    {
        _audioManager.StopAllAudioSource();
        gameOver.SetActive(true);
        Invoke("ShowGameOverMenu", 1f);
    }

    public void ShowGameOverMenu()
    {
        _audioManager.PlayMusic("GameOverMusic");
        gameOver.SetActive(false);
        Time.timeScale = 0;
        menuGameOver.SetActive(true);
    }

}



