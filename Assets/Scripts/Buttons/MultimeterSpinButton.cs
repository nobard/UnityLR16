using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// кнопка мультиметра
public class MultimeterSpinButton : MonoBehaviour, ILMButton, IRMButton
{
    [SerializeField] GameObject Multimeter;
    [SerializeField] GameObject ProgressManager;
    private Multimeter multimeter;
    private int position = 0; // текущая позиция кнопки

    void Start()
    {
        multimeter = Multimeter.GetComponent<Multimeter>();
    }

    public void LMBInteraction()
    {
        gameObject.transform.Rotate(0f, 0f, 18f);
        
        if(position == 19)
        {
            position = 0;
        }
        else
        {
            position++;
        }

        CheckAngle();
    }

    public void RMBInteraction()
    {
        gameObject.transform.Rotate(0f, 0f, -18f);

        if(position == 0)
        {
            position = 19;
        }
        else
        {
            position--;
        }

        CheckAngle();
    }

    void CheckAngle()
    {
        if(position == 4)
        {
            multimeter.ChangeDisplayText("0");
            multimeter.displayTurnedOn = true;
            //фиксация прогресса, 2 пункт
            // ProgressManager.GetComponent<ProgressManager>().SetProgress(1, true);
        }
        else
        {
            Multimeter.GetComponent<Multimeter>().ChangeDisplayText("");
            multimeter.displayTurnedOn = false;
        }
    }
}
