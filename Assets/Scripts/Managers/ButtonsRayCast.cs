using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// активация кнопок, поддержка работы кнопок, логика
public class ButtonsRayCast : MonoBehaviour
{
    public Camera cameraTR;
    private RaycastHit[] hits;

    public void Update()
    {
        if(UserInfo.IsLogged)
        {
            if(Input.GetMouseButtonDown(0))
            {
                InteractButton(true);
            }

            if(Input.GetMouseButtonDown(1))
            {
                InteractButton(false);
            }  
        }
        
    }

    void InteractButton(bool leftMB)
    {
        hits = Physics.RaycastAll(cameraTR.ScreenPointToRay(Input.mousePosition), 15);

        foreach(var hit in hits)
        {
            var collider = hit.collider;
            
            if(leftMB)
                if(collider.TryGetComponent(out ILMButton leftButton))
                {
                    leftButton.LMBInteraction();
                    break;
                }
            if(collider.TryGetComponent(out IRMButton rightButton))
            {
                rightButton.RMBInteraction();
                break;
            } 
        }
    }
}