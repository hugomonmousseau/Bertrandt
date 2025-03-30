using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private bool timerIsRunning = false;

    public IEnumerator RunTimer(float _timeRemaining)
    {
        timerIsRunning = true;
        while (timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                DisplayTime(_timeRemaining);
            }
            else
            {
                _timeRemaining = 0;
                timerIsRunning = false;
                SceneARManager.INSTANCE.EndTimer();
                DisplayTime(_timeRemaining);
            }
            yield return null;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float _minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float _seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
    }
}
