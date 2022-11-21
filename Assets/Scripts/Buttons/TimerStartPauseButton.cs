using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// старт/стоп секундомера
public class TimerStartPauseButton : MonoBehaviour, ILMButton
{
    [SerializeField] GameObject Timer;

    public void LMBInteraction()
    {
        Timer.GetComponent<StopWatch>().StartPauseTimer();
    }
}
