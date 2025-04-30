using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moneda : MonoBehaviour
{
    public int valor = 10;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            Debug.Log("Player tocó moneda. Valor: " + valor);
            ControladorMoneda cm = GameObject.Find("ContadorManager")?.GetComponent<ControladorMoneda>();
            if (cm != null)
            {
                cm.AgregarMonedas(valor);
            }

            Destroy(gameObject);
        }
    }
}



