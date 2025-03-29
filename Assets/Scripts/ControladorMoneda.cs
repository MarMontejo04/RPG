using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using TMPro;
 
 public class ControladorMoneda : MonoBehaviour
{
private int totalMonedas;
[SerializeField] private TMP_Text textoMonedas;

private void Start()
{
Moneda.sumaMoneda += SumarMonedas;
}

private void SumarMonedas (int moneda)
{
totalMonedas += moneda;
textoMonedas.text = totalMonedas.ToString();
}

}

     