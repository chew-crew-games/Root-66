using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider timeSlider;

    public float gameTime;

    private bool stopTimer;

    void Start()
    {
        stopTimer = false;
        timeSlider.maxValue = gameTime;
        timeSlider.value = gameTime;
       
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;
        
        if (time <= 0)
        {
            stopTimer = true;

            ResetTimer();
        }
        if (stopTimer == false)
        {
            timeSlider.value = time;
            
        }
        

    }
    public void ResetTimer()
    {
        timeSlider.maxValue = 20;
    }

}
