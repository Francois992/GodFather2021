using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public GameObject gameOverP1;
    public GameObject gameOverP2;

    [SerializeField] private float timeRemaining = 180;
    [SerializeField] private bool timerIsRunning = true;

    void Update()
    {
        if (timerIsRunning)
        {
            DisplayTime(timeRemaining);

            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerIsRunning = false;
                if(Score.instance.scoreP1 > Score.instance.scoreP2){
                    gameOverP1.SetActive(true);
                }
                else
                {
                    gameOverP2.SetActive(true);
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
