using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador_Monedas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public void aumentarContador(int coin)
    {
        text.text = "X" + coin;
    }
    public void reiniciarContador(int coin)
    {
        text.text= "X" + coin;
    }
}
