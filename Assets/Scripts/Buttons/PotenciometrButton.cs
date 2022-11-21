using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ручка потенциометра
public class PotenciometrButton : MonoBehaviour, ILMButton, IRMButton
{
    [SerializeField] GameObject PhysCalculations;
    private PhysCalculationsManager manager;

    void Start()
    {
        manager = PhysCalculations.GetComponent<PhysCalculationsManager>();
    }

    public void LMBInteraction()
    {
        if(manager.I < 150)
        {
            transform.Rotate(0f, 0f, 2.4f);
            manager.I++;
        }
        if(manager.I == 150)
        {
            manager.I = 0;
        }
    }

    public void RMBInteraction()
    {
        if(manager.I > 0)
        {
            transform.Rotate(0f, 0f, -2.4f);
            manager.I--;
        }
    }
}
