using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float timeRemaining = 60.0f;
    private bool timerIsRunning = false;

    public IEnumerator RunTimer()
    {
        timerIsRunning = true;
        while (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                SceneARManager.INSTANCE.EndTimer();
                DisplayTime(timeRemaining);
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
