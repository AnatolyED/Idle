using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private GameTime _gameTime;
    [SerializeField]
    private TextMeshProUGUI _timer;

    private void Start()
    {
        StartCoroutine(GameTimeUpdater());
    }
    private IEnumerator GameTimeUpdater()
    {
        while (true)
        {
            if (_gameTime.Seconds < 59)
            {
                _gameTime.Seconds += 1;
            }
            else if(_gameTime.Seconds >= 59 && _gameTime.Minets < 59)
            {
                _gameTime.Minets += 1;
                _gameTime.Seconds = 0;   
            }
            else
            {
                _gameTime.Hours += 1;
                _gameTime.Minets = 0;
                _gameTime.Seconds = 0;
            }

            TextTimerUpdater();
            yield return new WaitForSeconds(1f);
        }
    }
    private void TextTimerUpdater()
    {
        _timer.text = $"Время игры: {_gameTime.Hours}:{_gameTime.Minets}:{_gameTime.Seconds}";
    }
}

[System.Serializable]
public struct GameTime
{
    public int Hours;
    public int Minets;
    public int Seconds;
}
