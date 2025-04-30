using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ControladorMoneda : MonoBehaviour
{
    public TMP_Text contadorTexto;
    private int monedas;

    void Start()
    {
        monedas = 0;
        ActualizarTexto();
    }

    public void AgregarMonedas(int cantidad)
    {
        monedas += cantidad;
        ActualizarTexto();
    }

    public bool GastarMonedas(int cantidad)
{
    if (monedas >= cantidad)
    {
        monedas -= cantidad;
        ActualizarTexto();
        return true;
    }
    return false;
}


    private void ActualizarTexto()
    {
        if (contadorTexto != null)
        {
            contadorTexto.text = monedas.ToString();
        }
    }

    public int ObtenerMonedas()
    {
        return monedas;
    }
}


     