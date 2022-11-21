using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    //появление и исчезновение стрелок при наводе на коллайдер
    public GameObject Arrows;
    private void OnMouseEnter()
    {
        if(UserInfo.IsLogged) Arrows.SetActive(true);
    }

    private void OnMouseExit()
    {
        if(UserInfo.IsLogged) Arrows.SetActive(false);
    }
}
