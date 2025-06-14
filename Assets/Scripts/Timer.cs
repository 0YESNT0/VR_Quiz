using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] float maxTime = 60f;
    [SerializeField] float currentTime = 60f;
    [SerializeField] TextMeshProUGUI timeText;

    public static UnityEvent onTimerEnd;

    public bool timerRuns = false;

    public void Start()
    {
        currentTime = maxTime;
    }
    public void ResetTime(){
        currentTime = maxTime;
        timerRuns = true;
    }
    public void Update()
    {
        if (currentTime > 0){
            currentTime -= Time.deltaTime;
        }
        else{
            if(timerRuns == true){
                onTimerEnd?.Invoke();
                Debug.LogWarning("Timer Ended");
            }
            timerRuns = false;            
            
        }

        DisplayTime(currentTime);
    }

    void DisplayTime(float t){
        float min = Mathf.FloorToInt(t/60);
        float sec = Mathf.FloorToInt(t%60);

        timeText.text = string.Format("{0:00}:{1:00}",min,sec);
    }
}
