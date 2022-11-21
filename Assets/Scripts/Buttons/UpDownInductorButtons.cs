using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// поворот индуктора вертикально/горизонтально
public class UpDownInductorButtons : MonoBehaviour, ILMButton
{
    [SerializeField] GameObject Inductor;

    public void LMBInteraction()
    {
        Inductor.GetComponent<Rotation>().RotateInductor();
    }
}