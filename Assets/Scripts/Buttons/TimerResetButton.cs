using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// сброс секундомера
public class TimerResetButton : MonoBehaviour, ILMButton
{
    [SerializeField] GameObject Timer;

    public void LMBInteraction()
    {
        Timer.GetComponent<StopWatch>().ResetTimer();
    }
}
