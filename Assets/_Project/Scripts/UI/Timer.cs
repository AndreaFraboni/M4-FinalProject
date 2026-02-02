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

            Debug.Log("TEMPO SCADUTO !!!");

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
        _currentTime += value;
        if (_currentTime > _countDown) _currentTime = _countDown;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER !!!");
        
        // STOP all music ancd sfx now not play ==> isPlaying = false;
        _audioManager.StopAllAudioSource();

        // game in PAUSE ==> isPaused = true;
       
        gameOver.SetActive(true);

        // PLAY DEATH MUSIC
        
        // Show Game Over

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



