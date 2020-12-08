using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador_Vidas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public void bajarVida(int vida)
    {
        if (vida >= 0)
        {
            text.text = "X" + vida;
        }
        
    }
    public void subirVida(int vida)
    {
        text.text = "X" + vida;
    }
}
