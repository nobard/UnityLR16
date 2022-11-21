using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// физические вычисления
public class PhysCalculationsManager : MonoBehaviour
{
    [SerializeField] GameObject Inductor;
    [SerializeField] GameObject Multimeter;
    [SerializeField] Text data;
    [SerializeField] GameObject ProgressManager;

    private Multimeter multimeter;
    private float time;
    [HideInInspector] public float Ivh;
    private float Bv;
    private float Bh;
    private float B;
    private int N;
    private int R;
    private float S;
    private float alfa = 90f;
    private float d = 0.27f;
    [HideInInspector] public Rotation inductor;
    private float Ipart;
    private float U;
    private float Upart;
    private float omega;
    [HideInInspector] public float I; // в мкА
    [HideInInspector] public bool CircuetIsCorrect = false;

    [HideInInspector] public double iv;
    [HideInInspector] public double ih;

    void Start()
    {
        inductor = Inductor.GetComponent<Rotation>();
        multimeter = Multimeter.GetComponent<Multimeter>();

        Bv = PlayerPrefs.GetFloat("Bv") * Mathf.Pow(10, -5);
        Bh = PlayerPrefs.GetFloat("Bh") * Mathf.Pow(10, -5);
        N = PlayerPrefs.GetInt("N");
        R = PlayerPrefs.GetInt("r");
        I = PlayerPrefs.GetInt("I");
        S = d * d;
        Ipart = (12 * S * N) / (Mathf.PI * R);
        Upart = (4 * N * S) / (2 * 3.14f);

        iv = Math.Round(Ipart * Bv * Mathf.Pow(10, 6));
        ih = Math.Round(Ipart * Bh * Mathf.Pow(10, 6));

        data.text = 
            $"d = (27,0 ± 0,3) см \nN = {N} ± 3 \nR = ({R} ± 1) Ом \nIv = {iv} мкА \nIh = {ih} мкА";
    }
    
    void FixedUpdate()
    {
        time += 0.02f;

        if(CircuetIsCorrect)
        {
            alfa = (inductor.rotateDirection == 0 ? 90 : 0) * Mathf.Deg2Rad;
            omega = inductor.omegaX2 / 2;
            B = Bh * Mathf.Sin(alfa) + Bv * Mathf.Cos(alfa);
            U = Upart * B * omega;
            Ivh = I * Mathf.Pow(10, -6) - (U / R) + Mathf.Pow(10, -6) * Mathf.Sin(omega * time);

            if(multimeter.displayTurnedOn)
            {
                multimeter.ChangeDisplayText(Mathf.Round(I).ToString());
                
                //фиксация прогресса, 3 пункт
                // if(I > 0.95 * ih && I < 1.05 * ih)
                // {
                //     ProgressManager.GetComponent<ProgressManager>().SetProgress(2, true);
                // }
            }
        }
    }

    public void ResetCalculations()
    {
        CircuetIsCorrect = false;
        Ivh = 0;
        I = PlayerPrefs.GetInt("I");
        
        if(multimeter.displayTurnedOn)
        {
            multimeter.ChangeDisplayText("0");
        }
        else
        {
            multimeter.ChangeDisplayText("");
        }
    }
}