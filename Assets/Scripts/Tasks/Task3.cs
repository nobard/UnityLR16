using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task3 : MonoBehaviour, ITask
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
        var ih = obj.PhysCalcManager.GetComponent<PhysCalculationsManager>().ih;
        var calkManager = obj.PhysCalcManager.GetComponent<PhysCalculationsManager>();

        return I > 0.95 * ih && I < 1.05 * ih && calkManager.inductor.rotateDirection == 0;
    }

    public void ResetTask()
    {
        NextButton.GetComponent<Button>().interactable = false;
    }
}