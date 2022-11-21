using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task8 : MonoBehaviour, ITask
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
        var I = obj.PhysCalcManager.GetComponent<PhysCalculationsManager>().I;
        var iv = obj.PhysCalcManager.GetComponent<PhysCalculationsManager>().iv;
        var calkManager = obj.PhysCalcManager.GetComponent<PhysCalculationsManager>();

        return I > 0.95 * iv && I < 1.05 * iv && calkManager.inductor.rotateDirection == 1;
    }

    public void ResetTask()
    {
        NextButton.GetComponent<Button>().interactable = false;
    }
}