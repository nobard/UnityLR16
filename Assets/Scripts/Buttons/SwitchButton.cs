using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ручка ключа
public class SwitchButton : MonoBehaviour, ILMButton
{
    [SerializeField] GameObject CircuitManager;
    [SerializeField] GameObject CalcManager;
    [SerializeField] GameObject ProgressManager;
    [SerializeField] GameObject Message;
    
    bool turned = false; // true если опущен

    public void LMBInteraction()
    {
        if(turned)
        {
            transform.Rotate(0f, 0f, -50f);
            turned = false;
            CalcManager.GetComponent<PhysCalculationsManager>().ResetCalculations();
        } 
        else
        {
            transform.Rotate(0f, 0f, 50f);
            turned = true;
            CheckCircuitCorrectness();
        }
    }

    //проверка правильности сборки цепи
    void CheckCircuitCorrectness()
    {
        var manager = CircuitManager.GetComponent<CircuitManager>();
        foreach (var e in manager.relationsDictionary)
        {
            if(!manager.LogicFlag)
                if(!e.Value)
                {
                    StartCoroutine(ShowMessage());
                    return;
                }
        }

        CalcManager.GetComponent<PhysCalculationsManager>().CircuetIsCorrect = true;

        //фиксация прогресса, 1 пункт
        // ProgressManager.GetComponent<ProgressManager>().SetProgress(0, true);
    }

    IEnumerator ShowMessage()
    {
        Message.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Message.SetActive(false);
    }
}
