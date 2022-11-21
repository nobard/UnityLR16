using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// вспомогательный класс индикаторов
public class LevelScale : MonoBehaviour
{
    [SerializeField] GameObject Manager;
    public int I;

    void FixedUpdate()
    {
        I = (int)(Manager.GetComponent<PhysCalculationsManager>().Ivh * Mathf.Pow(10, 6));
    }
}