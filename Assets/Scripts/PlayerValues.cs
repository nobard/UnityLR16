using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// генерация случайных значений пользователя
public class PlayerValues : MonoBehaviour
{
    void Start()
    {
        // если нужна генерация значений при каждом перезапуске, нужно удалить if(), оставив саму генерацию
        //if(PlayerPrefs.GetFloat("Bh") == 0)
        {
            PlayerPrefs.SetFloat("Bh", Random.Range(1.05f, 1.15f)); // 1.05 * e-5   1.15 * e-5
            PlayerPrefs.SetFloat("Bv", Random.Range(3.33f, 3.68f)); // 3.33 * e-5   3.68 * e-5
            PlayerPrefs.SetInt("N", 900 + Random.Range(0, 20) * 10); // 900, 910... 1100
            PlayerPrefs.SetInt("r", 160 + Random.Range(0, 4) * 5); // 160, 165... 180
            PlayerPrefs.SetInt("I", Random.Range(30, 70)); // 30... 70 мкА
        }
    }
}
