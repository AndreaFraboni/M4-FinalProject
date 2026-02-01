using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _countDown = 600f; // Durata del timer in secondi = 10 minuti
    [SerializeField] private float _currentTime;
    [SerializeField] private TextMeshProUGUI _currentTimetext;

    private void Awake()
    {
        _currentTimetext.text = $"{(int)_currentTime} s";
        _currentTime = _countDown;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        TimeManager();

        if (_currentTime <= 0)
        {
            _currentTime = 0;

            Debug.Log("TEMPO SCADUTO !!!");

            Invoke("GameOver", 1);
        }
    }

    private void TimeManager()
    {
        int secondiTrascorsi = (int)_currentTime;
        _currentTimetext.text = $"{secondiTrascorsi} s";
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER !!!");
        // STOP all music ancd sfx now not play ==> isPlaying = false;
        // game in PAUSE ==> isPaused = true;
        Time.timeScale = 0;

        // PLAY DEATH MUSIC
        // Show Game Over
    }

}



