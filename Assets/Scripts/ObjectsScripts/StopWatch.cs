using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

// логика секундомера
public class StopWatch : MonoBehaviour
{
    private bool timerStarted = false; // true - секундомер запущен

    [HideInInspector] public float currentTime;
    public int ihMeteringCount;
     public int ivMeteringCount;

    [SerializeField] GameObject inductor;

    private void Update()
    {
        if(timerStarted)
        {
            currentTime += Time.deltaTime;
        }
        if((int)currentTime == 100)
        {
            currentTime = 0;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        GetComponent<TextMeshPro>().text = String.Format("{0:00\\.}{1:00}", (int)currentTime, time.ToString(@"ff"));
    }

    public void StartPauseTimer()
    {
        if(timerStarted)
        {
            timerStarted = false;
        }
        else
        {
            timerStarted = true;
        }
    }

    public void ResetTimer()
    {
        if(currentTime > 50)
        {
            if(inductor.GetComponent<Rotation>().rotateDirection == 0) ihMeteringCount++;
            else ivMeteringCount++;
        }
        
        currentTime = 0;
    }
}