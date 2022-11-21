using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// стрелки вращения индуктора
public class InductorButtons : MonoBehaviour, ILMButton
{
    [SerializeField] GameObject Inductor;
    [SerializeField] bool direction; // направление вращения true - вправо, false - влево
    
    public void LMBInteraction()
    {
        Inductor.GetComponent<Rotation>().ChangeSpeed(direction);
    }
}
