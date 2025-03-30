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
                DisplayTime(timeRemaining);
            }
            yield return null;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Pour afficher 1:00 au lieu de 0:59 à la fin

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
