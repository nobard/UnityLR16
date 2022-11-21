using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// логика работы индикатора
public class Indicator : MonoBehaviour
{
    [SerializeField] GameObject LevelScale;
    [SerializeField] float iToTurn; // в мкА
    [SerializeField] bool isPositive;

    private int I;
    private Color offColor;

    void Start()
    {
        offColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    void FixedUpdate()
    {
        I = LevelScale.GetComponent<LevelScale>().I;

        if(I > 0 && isPositive)
        {
            if(I > iToTurn)
            {
                TurnIndicator(Color.yellow);
            }
            if(I <= iToTurn)
            {
                TurnIndicator(offColor);
            }
        }
        else if(isPositive)
        {
            TurnIndicator(offColor);
        }

        if(I < 0 && !isPositive)
        {
            if(I < iToTurn)
            {
                TurnIndicator(Color.yellow);
            }
            if(I >= iToTurn)
            {
                TurnIndicator(offColor);
            }
        }
        else if(!isPositive)
        {
            TurnIndicator(offColor);
        }
    }

    void TurnIndicator(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
