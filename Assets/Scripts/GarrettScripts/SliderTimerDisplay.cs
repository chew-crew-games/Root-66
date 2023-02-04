using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimerDisplay : MonoBehaviour
{
    private float timeRemaining;
    private const float timerMax = 5f;
    public Slider slider;

    private void Update()
    {
        slider.value = CalculateSliderValue();

        if (Input.GetKeyDown(KeyCode.Space))
        {

            timeRemaining = timerMax;

        }

        if(timeRemaining <= 0)
        {

            timeRemaining = 0;

        }
        else if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

        }

    }

    float CalculateSliderValue()
    {
        return (timeRemaining / timerMax);

    }

}
