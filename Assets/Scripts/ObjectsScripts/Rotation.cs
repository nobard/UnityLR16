using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// вращение индуктора
public class Rotation : MonoBehaviour
{
    public GameObject parent;
    private float step = 7.2f / 12.57f; //0,5 рад/с
    public float omegaX2 = 0; //текущая скорость вращения
    public int rotateDirection = 0; //вращение: 0 - вертикально, 1 - горизонтально

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0f, omegaX2 * step, 0f); // вращение индуктора
    }

    public void ChangeSpeed(bool direction)
    {
        //изменение скорости индуктора
        if(direction)
            omegaX2++;
        else
            omegaX2--;
    }

    public void RotateInductor()
    {
        if(rotateDirection == 0)
        {
            parent.transform.Rotate(90.0f, 0.0f, 0.0f);
            rotateDirection++;
            omegaX2 = 0;
        }
        else
        {
            parent.transform.Rotate(-90.0f, 0.0f, 0.0f);
            rotateDirection--;
            omegaX2 = 0;
        }
    }
}