using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task5 : MonoBehaviour, ITask
{
    public bool isResolved { get; set; }
    public GameObject NextButton { get; set; }
    [SerializeField] GameObject nextButton;

    void Awake()
    {
        NextButton = nextButton;
    }
    
    public bool TaskCondition(ProgressManager obj) 
    {
        var calkManager = obj.PhysCalcManager.GetComponent<PhysCalculationsManager>();
        var i = calkManager.Ivh * Mathf.Pow(10, 6);

        if(calkManager.CircuetIsCorrect && calkManager.inductor.rotateDirection == 0 && i != 0) 
            return i < 0.2 && i > -0.2 && obj.StopWatch.GetComponent<StopWatch>().currentTime >= 50;

        return false;
    }

    public void ResetTask()
    {
        NextButton.GetComponent<Button>().interactable = false;
    }
}